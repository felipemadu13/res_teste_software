using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.Entity;
using eCommerce.Repository;

namespace eCommerce.Services
{
    public class CarrinhoDeComprasService
    {
        private readonly ICarrinhoDeComprasRepository _repository;

        public CarrinhoDeComprasService(ICarrinhoDeComprasRepository repository)
        {
            _repository = repository;
        }

        public CarrinhoDeComprasService()
        {

        }

        public virtual CarrinhoDeCompras BuscarPorCarrinhoIdEClienteId(long carrinhoId, Cliente cliente)
        {
            // var carrinho = _repository.FindByIdAsync(carrinhoId).Result; // Busca o carrinho pelo ID
            var carrinho = _repository.FindByIdAndClienteAsync(carrinhoId, cliente).Result;

            if (carrinho == null || carrinho.Cliente.Id != cliente.Id)
            {
                throw new ArgumentException("Carrinho não encontrado.");
            }

            return carrinho; // Retorna o carrinho se encontrado
        }
    }
}