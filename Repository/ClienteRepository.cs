using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;

namespace eCommerce.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly List<Cliente> _clientes;

        public ClienteRepository()
        {
            _clientes = new List<Cliente>();
            SeedData(); // Chama o método para adicionar dados pré-cadastrados
        }

        private void SeedData()
        {
            // Criação de clientes fictícios
            var cliente1 = new Cliente(1, "João Silva", "Rua A", TipoCliente.OURO);
            var cliente2 = new Cliente(2, "Maria Oliveira", "Rua B", TipoCliente.PRATA);

            // Adiciona os clientes à lista
            _clientes.Add(cliente1);
            _clientes.Add(cliente2);
        }

        public async Task<Cliente> FindByIdAsync(long id)
        {
            return await Task.FromResult(_clientes.FirstOrDefault(c => c.Id == id));
        }

        public async Task AddAsync(Cliente cliente)
        {
            await Task.Run(() => _clientes.Add(cliente));
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            await Task.Run(() =>
            {
                var existingCliente = _clientes.FirstOrDefault(c => c.Id == cliente.Id);
                if (existingCliente != null)
                {
                    _clientes.Remove(existingCliente);
                    _clientes.Add(cliente);
                }
            });
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            await Task.Run(() => _clientes.Remove(cliente));
        }
    }
}