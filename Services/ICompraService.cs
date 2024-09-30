using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;
using eCommerce.Domain.Entity;

namespace eCommerce.Services
{
    public interface ICompraService
    {
        public Task<CompraDTO> FinalizarCompraAsync(long carrinhoId, long clienteId);
        public decimal CalcularCustoTotal(CarrinhoDeCompras carrinho);
    }
}