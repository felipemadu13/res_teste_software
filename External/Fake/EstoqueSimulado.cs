using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;

namespace eCommerce.External.Fake
{
    public class EstoqueSimulado : IEstoqueExternal
    {
        // Simulação de dados de estoque
        private readonly Dictionary<long, long> _estoque = new()
        {
            { 1, 10 }, // Produto ID 1 tem 10 unidades disponíveis
            { 2, 5 },  // Produto ID 2 tem 5 unidades disponíveis
            { 3, 1 },   // Produto ID 3 está fora de estoque
            { 4, 0 }   // Produto ID 3 está fora de estoque
        };

        public EstoqueBaixaDTO DarBaixa(List<long> produtosIds, List<long> produtosQuantidades)
        {
            // Verifica se a baixa pode ser realizada
            for (int i = 0; i < produtosIds.Count; i++)
            {
                var produtoId = produtosIds[i];
                var quantidade = produtosQuantidades[i];

                if (!_estoque.ContainsKey(produtoId) || _estoque[produtoId] < quantidade)
                {
                    return new EstoqueBaixaDTO(false); // Falha na baixa
                }
            }

            // Realiza a baixa de estoque
            for (int i = 0; i < produtosIds.Count; i++)
            {
                var produtoId = produtosIds[i];
                var quantidade = produtosQuantidades[i];

                _estoque[produtoId] -= quantidade;
            }

            return new EstoqueBaixaDTO(true); // Sucesso na baixa
        }
        public DisponibilidadeDTO VerificarDisponibilidade(List<long> produtosIds, List<long> produtosQuantidades)
        {
            var indisponiveis = new List<long>();

            // Verifica a disponibilidade dos produtos
            for (int i = 0; i < produtosIds.Count; i++)
            {
                var produtoId = produtosIds[i];
                var quantidade = produtosQuantidades[i];

                if (!_estoque.ContainsKey(produtoId) || _estoque[produtoId] < quantidade)
                {
                    indisponiveis.Add(produtoId); // Adiciona à lista de produtos indisponíveis
                }
            }

            return new DisponibilidadeDTO(indisponiveis.Count == 0, indisponiveis);
        }
    }
}