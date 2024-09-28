using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Entity;

namespace eCommerce.Repository
{
    public interface IProdutoRepository
    {
        Task<Produto> FindByIdAsync(long id);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(Produto produto);
    }
}