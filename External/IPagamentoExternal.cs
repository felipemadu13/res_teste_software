using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;

namespace eCommerce.External
{
    public interface IPagamentoExternal
    {
        PagamentoDTO AutorizarPagamento(long clienteId, double custoTotal);

	    void CancelarPagamento(long clienteId, long pagamentoTransacaoId);
    }
}