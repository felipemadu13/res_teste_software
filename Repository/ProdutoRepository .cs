using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;
using Ecommerce.Entity;

namespace eCommerce.Repository
{
    public class ProdutoRepository 
    {
         private readonly List<Produto> _produtos;

        public ProdutoRepository()
        {
            _produtos = new List<Produto>();
            SeedData(); // Chama o método para adicionar dados pré-cadastrados
        }

        private void SeedData()
        {
            // Criação de produtos fictícios
            var produto1 = new Produto(1, "Laptop", "Laptop Gamer", 4999.99m, 2500, TipoProduto.ELETRONICO);
            var produto2 = new Produto(2, "Camiseta", "Camiseta de Algodão", 49.99m, 200, TipoProduto.ROUPA);

            // Adiciona os produtos à lista
            _produtos.Add(produto1);
            _produtos.Add(produto2);
        }

        public async Task<Produto> FindByIdAsync(long id)
        {
            return await Task.FromResult(_produtos.FirstOrDefault(p => p.Id == id));
        }

        public async Task AddAsync(Produto produto)
        {
            await Task.Run(() => _produtos.Add(produto));
        }

        public async Task UpdateAsync(Produto produto)
        {
            await Task.Run(() =>
            {
                var existingProduto = _produtos.FirstOrDefault(p => p.Id == produto.Id);
                if (existingProduto != null)
                {
                    _produtos.Remove(existingProduto);
                    _produtos.Add(produto);
                }
            });
        }

        public async Task DeleteAsync(Produto produto)
        {
            await Task.Run(() => _produtos.Remove(produto));
        }
    }
}