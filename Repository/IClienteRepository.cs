using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;

namespace eCommerce.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> FindByIdAsync(long id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(Cliente cliente);
    }
}