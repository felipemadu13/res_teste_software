using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;
using eCommerce.Domain.Entity;
using eCommerce.External;
using eCommerce.Services;
using Ecommerce.Entity;

namespace ecommerce.Services
{
    public class CompraService
    {
        private readonly CarrinhoDeComprasService _carrinhoService;
        private readonly ClienteService _clienteService;
        private readonly IEstoqueExternal _estoqueExternal;
        private readonly IPagamentoExternal _pagamentoExternal;

        // Simulações em memória
        private readonly Dictionary<long, Cliente> _clientes = new();
        private readonly Dictionary<long, Produto> _produtos = new();
        private readonly Dictionary<long, CarrinhoDeCompras> _carrinhos = new();
        public CompraService()
        {
            
        }
        public CompraService(CarrinhoDeComprasService carrinhoService,
                             ClienteService clienteService,
                             IEstoqueExternal estoqueExternal,
                             IPagamentoExternal pagamentoExternal)
        {
            _carrinhoService = carrinhoService;
            _clienteService = clienteService;
            _estoqueExternal = estoqueExternal;
            _pagamentoExternal = pagamentoExternal;

            InicializarDadosEmMemoria();
        }
        private void InicializarDadosEmMemoria()
        {
            // Inicializa alguns clientes
            _clientes[1] = new Cliente(1, "Cliente 1", "Endereco 1", TipoCliente.PRATA);
            _clientes[2] = new Cliente(2, "Cliente 2", "Endereco 2", TipoCliente.OURO);

            // Inicializa alguns produtos
            _produtos[1] = new Produto(1, "Smartphone", "Um smartphone com várias funcionalidades", 1999.99m, 200, TipoProduto.ELETRONICO);
            _produtos[2] = new Produto(2, "Camiseta", "Camiseta de algodão", 49.90m, 150, TipoProduto.ROUPA);
            _produtos[3] = new Produto(3, "Chocolate", "Chocolate ao leite", 5.50m, 100, TipoProduto.ALIMENTO);


            // Inicializa um carrinho de compras
            var carrinho = new CarrinhoDeCompras(1, _clientes[1], new List<ItemCompra>
            {
                new ItemCompra(1, _produtos[2], 1),
                new ItemCompra(2, _produtos[3], 1)
            }, DateTime.Now);
            _carrinhos[1] = carrinho;
        }

        public virtual async Task<CompraDTO> FinalizarCompraAsync(long carrinhoId, long clienteId)
        {
            if (!_clientes.TryGetValue(clienteId, out var cliente) || !_carrinhos.TryGetValue(carrinhoId, out var carrinho))
            {
                throw new ArgumentException("Cliente ou carrinho não encontrado.");
            }

            var produtosIds = carrinho.Itens.Select(i => i.Produto.Id).ToList();
            var produtosQtds = carrinho.Itens.Select(i => i.Quantidade).ToList();

            var disponibilidade = _estoqueExternal.VerificarDisponibilidade(produtosIds, produtosQtds);

            if (!disponibilidade.Disponivel)
            {
                throw new InvalidOperationException("Itens fora de estoque.");
            }

            var custoTotal = CalcularCustoTotal(carrinho);

            var pagamento =  _pagamentoExternal.AutorizarPagamento(cliente.Id, decimal.ToDouble(custoTotal));

            if (!pagamento.Autorizado)
            {
                throw new InvalidOperationException("Pagamento não autorizado.");
            }

            var baixaDTO = _estoqueExternal.DarBaixa(produtosIds, produtosQtds);

            if (!baixaDTO.Sucesso)
            {
                _pagamentoExternal.CancelarPagamento(cliente.Id, pagamento.TransacaoId);
                throw new InvalidOperationException("Erro ao dar baixa no estoque.");
            }

            return new CompraDTO(true, pagamento.TransacaoId, "Compra finalizada com sucesso.");
        }

        private decimal CalcularFrete(decimal peso)
        {
            decimal frete = 0;

            if(peso > 5 && peso <= 10)
            {
                frete += peso * 2;
            }
            else if( peso > 10 && peso <= 50)
            {
                frete += peso * 4;
            }
            else if( peso > 50 )
            {
                frete += peso * 7;
            }

            return frete;
        }

        public decimal CalcularCustoTotal(CarrinhoDeCompras carrinho)
        {
            var custoProdutos = carrinho.Itens.Sum(item => item.Produto.Preco * item.Quantidade);
            var pesoProdutos = carrinho.Itens.Sum(item => item.Produto.Peso * item.Quantidade);
            decimal frete = CalcularFrete(pesoProdutos);

            switch(carrinho.Cliente.Tipo)
            {
                case TipoCliente.OURO:
                    frete = 0;
                break;
                case TipoCliente.PRATA:
                    frete *= 0.5m;
                break;
                case TipoCliente.BRONZE:
                default:
                break;
            }

            if(custoProdutos > 500 && custoProdutos <= 1000)
            {
                custoProdutos = custoProdutos - (custoProdutos * 0.1m);
            }
            else if(custoProdutos > 1000)
            {
                custoProdutos = custoProdutos - (custoProdutos * 0.2m);
            }

            return custoProdutos + frete;
        }

    }
}
