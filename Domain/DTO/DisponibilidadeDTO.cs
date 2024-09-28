using System.Collections.Generic;

namespace eCommerce.Domain.DTO
{
    public class DisponibilidadeDTO
    {
        public bool Disponivel { get; init; }
        public List<long> IdsProdutosIndisponiveis { get; init; }

        public DisponibilidadeDTO(bool disponivel, List<long> idsProdutosIndisponiveis)
        {
            Disponivel = disponivel;
            IdsProdutosIndisponiveis = idsProdutosIndisponiveis;
        }
    }
}
