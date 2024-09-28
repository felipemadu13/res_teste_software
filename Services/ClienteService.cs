using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;
using eCommerce.Repository;

namespace eCommerce.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService()
        {

        }

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public virtual Cliente BuscarPorId(long clienteId)
        {
            var cliente = _repository.FindByIdAsync(clienteId).Result; // Busca o cliente pelo ID
            
            if (cliente == null)
            {
                throw new ArgumentException("Cliente não encontrado");
            }

            return cliente; // Retorna o cliente se encontrado
        }
    }
}