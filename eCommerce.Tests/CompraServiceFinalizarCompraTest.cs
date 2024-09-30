using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;
using eCommerce.Domain.Entity;
using eCommerce.External;
using eCommerce.Services;
using Ecommerce.Entity;
using Moq;
using Xunit;

namespace ecommerce.Services.Tests
{
    public class CompraServiceFinalizarCompraTest
    {
        private readonly Mock<CarrinhoDeComprasService> _carrinhoServiceMock;
        private readonly Mock<ClienteService> _clienteServiceMock;
        private readonly Mock<IEstoqueExternal> _estoqueExternalMock;
        private readonly Mock<IPagamentoExternal> _pagamentoExternalMock;
        private readonly CompraService _service;

        public CompraServiceFinalizarCompraTest()
        {
            _carrinhoServiceMock = new Mock<CarrinhoDeComprasService>();
            _clienteServiceMock = new Mock<ClienteService>();
            _estoqueExternalMock = new Mock<IEstoqueExternal>();
            _pagamentoExternalMock = new Mock<IPagamentoExternal>();

            _service = new CompraService(
                _carrinhoServiceMock.Object,
                _clienteServiceMock.Object,
                _estoqueExternalMock.Object,
                _pagamentoExternalMock.Object
            );
        }

        [Theory]
        [InlineData(1, 1, true, true, true)]  // Cliente e carrinho existentes, estoque disponível, pagamento autorizado, baixa bem-sucedida
        [InlineData(1, 1, false, true, true)] // Cliente e carrinho existentes, estoque indisponível
        [InlineData(1, 1, true, false, true)] // Cliente e carrinho existentes, pagamento não autorizado
        [InlineData(99, 1, true, true, true)] // Cliente não existente
        [InlineData(1, 99, true, true, true)] // Carrinho não existente
        [InlineData(1, 1, true, true, false)] // Baixa de estoque falha, pagamento cancelado com sucesso
        public async Task FinalizarCompraAsync_TestCases(long clienteId, long carrinhoId, bool estoqueDisponivel, bool pagamentoAutorizado, bool baixaEstoqueSucesso)
        {
            // Arrange
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);
            var produto = new Produto(1, "Produto Teste", "Descrição Teste", 10m, 5, TipoProduto.ELETRONICO);
            var carrinho = new CarrinhoDeCompras(carrinhoId, cliente, new List<ItemCompra> { new ItemCompra(1, produto, 2) }, DateTime.Now);
            var pagamento = new PagamentoDTO(pagamentoAutorizado, 12345);
            var disponibilidade = new DisponibilidadeDTO(true, new List<long>());
            var baixaDTO = new EstoqueBaixaDTO(baixaEstoqueSucesso);

            // Configuração dos Mocks para retorno esperado
            _clienteServiceMock.Setup(x => x.BuscarPorId(It.IsAny<long>())).Returns((long id) => id == clienteId ? cliente : null);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns((long carrinhoId, Cliente c) => c.Id == clienteId ? carrinho : null);

            _estoqueExternalMock.Setup(x => x.VerificarDisponibilidade(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(disponibilidade);
            _pagamentoExternalMock.Setup(x => x.AutorizarPagamento(It.IsAny<long>(), It.IsAny<double>())).Returns(pagamento);
            _estoqueExternalMock.Setup(x => x.DarBaixa(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(baixaDTO);
            _pagamentoExternalMock.Setup(x => x.CancelarPagamento(It.IsAny<long>(), It.IsAny<int>())).Verifiable();

            // Act & Assert
            if (cliente == null || carrinho == null)
            {
                // Expect ArgumentException for cliente ou carrinho não encontrado
                await Assert.ThrowsAsync<ArgumentException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
            }
            else if (!estoqueDisponivel)
            {
                // Expect InvalidOperationException for itens fora de estoque
                await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
            }
            else if (!pagamentoAutorizado)
            {
                // Expect InvalidOperationException for pagamento não autorizado
                await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
            }
            else if (!baixaEstoqueSucesso)
            {
                // Expect InvalidOperationException for erro ao dar baixa no estoque
                await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
                _pagamentoExternalMock.Verify(x => x.CancelarPagamento(cliente.Id, pagamento.TransacaoId), Times.Once);
            }
            else
            {
                // Expect successful purchase
                var result = await _service.FinalizarCompraAsync(carrinhoId, clienteId);
                Assert.NotNull(result);
                Assert.True(result.Sucesso);
                Assert.Equal("Compra finalizada com sucesso.", result.Mensagem);
            }
        }
    }
}
