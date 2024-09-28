using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;

namespace eCommerce.External
{
    public interface IEstoqueExternal
    {
        
        public EstoqueBaixaDTO DarBaixa(List<long> produtosIds, List<long> produtosQuantidades);

        public DisponibilidadeDTO VerificarDisponibilidade(List<long> produtosIds, List<long> produtosQuantidades);
        
    }
}