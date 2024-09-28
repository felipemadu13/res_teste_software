using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;

namespace eCommerce.Repository
{
    public interface ICarrinhoDeComprasRepository
    {
        Task<CarrinhoDeCompras> FindByIdAndClienteAsync(long id, Cliente cliente);
        Task<CarrinhoDeCompras> FindByIdAsync(long id);
        Task AddAsync(CarrinhoDeCompras carrinho);
        Task UpdateAsync(CarrinhoDeCompras carrinho);
        Task DeleteAsync(CarrinhoDeCompras carrinho);
    }
}