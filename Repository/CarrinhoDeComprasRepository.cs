using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;
using Ecommerce.Entity;

namespace eCommerce.Repository
{
    public class CarrinhoDeComprasRepository : ICarrinhoDeComprasRepository
    {
        private readonly List<CarrinhoDeCompras> _carrinhosDeCompras;
         private void SeedData()
        {
            // Criação de clientes fictícios
            var cliente1 = new Cliente(1, "João Silva", "Rua A", TipoCliente.OURO);
            var cliente2 = new Cliente(2, "Maria Oliveira", "Rua B", TipoCliente.PRATA);

            // Criação de carrinhos de compras pré-cadastrados
            var carrinho1 = new CarrinhoDeCompras(1, cliente1, new List<ItemCompra>(), DateTime.Now);
            var carrinho2 = new CarrinhoDeCompras(2, cliente2, new List<ItemCompra>(), DateTime.Now);

            // Adiciona os carrinhos à lista
            _carrinhosDeCompras.Add(carrinho1);
            _carrinhosDeCompras.Add(carrinho2);
        }
        public CarrinhoDeComprasRepository()
        {
            _carrinhosDeCompras = new List<CarrinhoDeCompras>();
            SeedData(); // Chama o método para adicionar dados pré-cadastrados
        }

         public async Task<CarrinhoDeCompras> FindByIdAndClienteAsync(long id, Cliente cliente)
        {
            return await Task.FromResult(_carrinhosDeCompras
                .FirstOrDefault(c => c.Id == id && c.Cliente.Id == cliente.Id));
        }

        public async Task<CarrinhoDeCompras> FindByIdAsync(long id)
        {
            return await Task.FromResult(_carrinhosDeCompras
                .FirstOrDefault(c => c.Id == id));
        }

        public async Task AddAsync(CarrinhoDeCompras carrinho)
        {
            await Task.Run(() => _carrinhosDeCompras.Add(carrinho));
        }

        public async Task UpdateAsync(CarrinhoDeCompras carrinho)
        {
            await Task.Run(() =>
            {
                var existingCarrinho = _carrinhosDeCompras.FirstOrDefault(c => c.Id == carrinho.Id);
                if (existingCarrinho != null)
                {
                    _carrinhosDeCompras.Remove(existingCarrinho);
                    _carrinhosDeCompras.Add(carrinho);
                }
            });
        }

        public async Task DeleteAsync(CarrinhoDeCompras carrinho)
        {
            await Task.Run(() => _carrinhosDeCompras.Remove(carrinho));
        }
    }
}