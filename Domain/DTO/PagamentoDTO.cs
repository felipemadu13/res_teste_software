using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Domain.DTO
{
    public class PagamentoDTO
    {
        public bool Autorizado { get; init; }
        public long TransacaoId { get; init; }

        public PagamentoDTO(bool autorizado, long transacaoId)
        {
            Autorizado = autorizado;
            TransacaoId = transacaoId;
        }
    }
}