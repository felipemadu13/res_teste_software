using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Domain.DTO;

namespace eCommerce.External.Fake
{
    public class PagamentoSimulado : IPagamentoExternal
    {
        public PagamentoDTO AutorizarPagamento(long clienteId, double custoTotal)
        {
            // Simulação de autorização de pagamento
            // Aqui você pode aplicar regras de negócio para simular a autorização
            bool autorizado = custoTotal < 3000; // Exemplo: autoriza pagamentos abaixo de R$ 1000
            long transacaoId = autorizado ? DateTime.Now.Ticks : 0; // Usa o timestamp como ID da transação

            return new PagamentoDTO(autorizado, transacaoId);
        }

        public void CancelarPagamento(long clienteId, long pagamentoTransacaoId)
        {
            // Simulação de cancelamento de pagamento
            // Neste exemplo, não estamos mantendo estado, então não há lógica aqui
            Console.WriteLine($"Pagamento com transação ID {pagamentoTransacaoId} cancelado para o cliente {clienteId}.");
        }
    }
}