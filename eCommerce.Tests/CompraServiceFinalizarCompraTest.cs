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

        [Fact]
        public async Task FinalizarCompraAsync_Sucesso_DeveRetornarCompraDTO()
        {
            // Arrange
            long clienteId = 1;
            long carrinhoId = 1;
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);
            var produto = new Produto(1, "Produto Teste", "Descrição Teste", 10m, 5, TipoProduto.ELETRONICO);
            var carrinho = new CarrinhoDeCompras(carrinhoId, cliente, new List<ItemCompra> { new ItemCompra(1, produto, 2) }, DateTime.Now);
            var pagamento = new PagamentoDTO(true, 12345);
            var disponibilidade = new DisponibilidadeDTO(true, new List<long>());
            var baixaDTO = new EstoqueBaixaDTO(true);

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns(cliente);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns(carrinho);
            _estoqueExternalMock.Setup(x => x.VerificarDisponibilidade(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(disponibilidade);
            _pagamentoExternalMock.Setup(x => x.AutorizarPagamento(It.IsAny<long>(), It.IsAny<double>())).Returns(pagamento);
            _estoqueExternalMock.Setup(x => x.DarBaixa(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(baixaDTO);

            // Act
            var result = await _service.FinalizarCompraAsync(carrinhoId, clienteId);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Sucesso);
            Assert.Equal("Compra finalizada com sucesso.", result.Mensagem);
        }

        [Fact]
        public async Task FinalizarCompraAsync_EstoqueIndisponivel_DeveLancarExcecao()
        {
            // Arrange
            long clienteId = 1;
            long carrinhoId = 1;
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);
            var produto = new Produto(1, "Produto Teste", "Descrição Teste", 10m, 5, TipoProduto.ELETRONICO);
            var carrinho = new CarrinhoDeCompras(carrinhoId, cliente, new List<ItemCompra> { new ItemCompra(1, produto, 2) }, DateTime.Now);
            var disponibilidade = new DisponibilidadeDTO(false, new List<long> { 1 });

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns(cliente);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns(carrinho);
            _estoqueExternalMock.Setup(x => x.VerificarDisponibilidade(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(disponibilidade);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
        }

        [Fact]
        public async Task FinalizarCompraAsync_PagamentoNaoAutorizado_DeveLancarExcecao()
        {
            // Arrange
            long clienteId = 1;
            long carrinhoId = 1;
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);
            var produto = new Produto(1, "Produto Teste", "Descrição Teste", 10m, 5, TipoProduto.ELETRONICO);
            var carrinho = new CarrinhoDeCompras(carrinhoId, cliente, new List<ItemCompra> { new ItemCompra(1, produto, 2) }, DateTime.Now);
            var disponibilidade = new DisponibilidadeDTO(true, new List<long>());
            var pagamento = new PagamentoDTO(false, 12345);

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns(cliente);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns(carrinho);
            _estoqueExternalMock.Setup(x => x.VerificarDisponibilidade(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(disponibilidade);
            _pagamentoExternalMock.Setup(x => x.AutorizarPagamento(It.IsAny<long>(), It.IsAny<double>())).Returns(pagamento);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
        }

        [Fact]
        public async Task FinalizarCompraAsync_ClienteNaoEncontrado_DeveLancarArgumentException()
        {
            // Arrange
            long clienteId = 99; // ID não existente
            long carrinhoId = 1;

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns((Cliente)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
        }

        [Fact]
        public async Task FinalizarCompraAsync_CarrinhoNaoEncontrado_DeveLancarArgumentException()
        {
            // Arrange
            long clienteId = 1;
            long carrinhoId = 99; // ID não existente
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns(cliente);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns((CarrinhoDeCompras)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
        }

        [Fact]
        public async Task FinalizarCompraAsync_BaixaEstoqueFalha_DeveLancarExcecao()
        {
            // Arrange
            long clienteId = 1;
            long carrinhoId = 1;
            var cliente = new Cliente(clienteId, "Cliente Teste", "Endereco Teste", TipoCliente.PRATA);
            var produto = new Produto(1, "Produto Teste", "Descrição Teste", 10m, 5, TipoProduto.ELETRONICO);
            var carrinho = new CarrinhoDeCompras(carrinhoId, cliente, new List<ItemCompra> { new ItemCompra(1, produto, 2) }, DateTime.Now);
            var disponibilidade = new DisponibilidadeDTO(true, new List<long>());
            var pagamento = new PagamentoDTO(true, 12345);
            var baixaDTO = new EstoqueBaixaDTO(false);

            _clienteServiceMock.Setup(x => x.BuscarPorId(clienteId)).Returns(cliente);
            _carrinhoServiceMock.Setup(x => x.BuscarPorCarrinhoIdEClienteId(carrinhoId, cliente)).Returns(carrinho);
            _estoqueExternalMock.Setup(x => x.VerificarDisponibilidade(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(disponibilidade);
            _pagamentoExternalMock.Setup(x => x.AutorizarPagamento(It.IsAny<long>(), It.IsAny<double>())).Returns(pagamento);
            _estoqueExternalMock.Setup(x => x.DarBaixa(It.IsAny<List<long>>(), It.IsAny<List<long>>())).Returns(baixaDTO);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _service.FinalizarCompraAsync(carrinhoId, clienteId));
            _pagamentoExternalMock.Verify(x => x.CancelarPagamento(cliente.Id, pagamento.TransacaoId), Times.Once);
        }
    }
}
