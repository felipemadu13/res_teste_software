
# Tabela de Decisão para Cálculo do Custo da Compra

| Peso Total (kg)         | Valor dos Itens (R$)     | Tipo de Cliente | Valor Frete por kg (R$) | Desconto no Frete (%) | Desconto no Valor dos Itens (%) | Valor Final Total (R$)                         |
|-------------------------|-------------------------|-----------------|------------------------|----------------------|---------------------------------|------------------------------------------------|
| Peso ≤ 5                | Valor ≤ 500             | Ouro            | 0                      | 100%                 | 0%                              | Valor dos itens                                |
| Peso ≤ 5                | 500 < Valor ≤ 1000      | Ouro            | 0                      | 100%                 | 10%                             | Valor dos itens * 0,90                        |
| Peso ≤ 5                | Valor > 1000            | Ouro            | 0                      | 100%                 | 20%                             | Valor dos itens * 0,80                        |
| Peso ≤ 5                | Valor ≤ 500             | Prata           | 0                      | 50%                  | 0%                              | Valor dos itens                                |
| Peso ≤ 5                | 500 < Valor ≤ 1000      | Prata           | 0                      | 50%                  | 10%                             | Valor dos itens * 0,90                        |
| Peso ≤ 5                | Valor > 1000            | Prata           | 0                      | 50%                  | 20%                             | Valor dos itens * 0,80                        |
| Peso ≤ 5                | Valor ≤ 500             | Bronze          | 0                      | 0%                   | 0%                              | Valor dos itens                                |
| Peso ≤ 5                | 500 < Valor ≤ 1000      | Bronze          | 0                      | 0%                   | 10%                             | Valor dos itens * 0,90                        |
| Peso ≤ 5                | Valor > 1000            | Bronze          | 0                      | 0%                   | 20%                             | Valor dos itens * 0,80                        |
| 5 < Peso ≤ 10           | Valor ≤ 500             | Ouro            | 2                      | 100%                 | 0%                              | Valor dos itens                                |
| 5 < Peso ≤ 10           | 500 < Valor ≤ 1000      | Ouro            | 2                      | 100%                 | 10%                             | Valor dos itens * 0,90                        |
| 5 < Peso ≤ 10           | Valor > 1000            | Ouro            | 2                      | 100%                 | 20%                             | Valor dos itens * 0,80                        |
| 5 < Peso ≤ 10           | Valor ≤ 500             | Prata           | 2                      | 50%                  | 0%                              | Valor dos itens + Peso * (Valor Frete * 0,5)  |
| 5 < Peso ≤ 10           | 500 < Valor ≤ 1000      | Prata           | 2                      | 50%                  | 10%                             | Valor dos itens * 0,90 + Peso * (Valor Frete * 0,5)  |
| 5 < Peso ≤ 10           | Valor > 1000            | Prata           | 2                      | 50%                  | 20%                             | Valor dos itens * 0,80 + Peso * (Valor Frete * 0,5)  |
| 5 < Peso ≤ 10           | Valor ≤ 500             | Bronze          | 2                      | 0%                   | 0%                              | Valor dos itens + Peso * Valor Frete          |
| 5 < Peso ≤ 10           | 500 < Valor ≤ 1000      | Bronze          | 2                      | 0%                   | 10%                             | Valor dos itens * 0,90 + Peso * Valor Frete          |
| 5 < Peso ≤ 10           | Valor > 1000            | Bronze          | 2                      | 0%                   | 20%                             | Valor dos itens * 0,80 + Peso * Valor Frete          |
| 10 < Peso ≤ 50          | Valor ≤ 500             | Ouro            | 4                      | 100%                 | 0%                              | Valor dos itens                                |
| 10 < Peso ≤ 50          | 500 < Valor ≤ 1000      | Ouro            | 4                      | 100%                 | 10%                             | Valor dos itens * 0,90                        |
| 10 < Peso ≤ 50          | Valor > 1000            | Ouro            | 4                      | 100%                 | 20%                             | Valor dos itens * 0,80                        |
| 10 < Peso ≤ 50          | Valor ≤ 500             | Prata           | 4                      | 50%                  | 0%                              | Valor dos itens + Peso * (Valor Frete * 0,5)  |
| 10 < Peso ≤ 50          | 500 < Valor ≤ 1000      | Prata           | 4                      | 50%                  | 10%                             | Valor dos itens * 0,90 + Peso * (Valor Frete * 0,5)  |
| 10 < Peso ≤ 50          | Valor > 1000            | Prata           | 4                      | 50%                  | 20%                             | Valor dos itens * 0,80 + Peso * (Valor Frete * 0,5)  |
| 10 < Peso ≤ 50          | Valor ≤ 500             | Bronze          | 4                      | 0%                   | 0%                              | Valor dos itens + Peso * Valor Frete          |
| 10 < Peso ≤ 50          | 500 < Valor ≤ 1000      | Bronze          | 4                      | 0%                   | 10%                             | Valor dos itens * 0,90 + Peso * Valor Frete          |
| 10 < Peso ≤ 50          | Valor > 1000            | Bronze          | 4                      | 0%                   | 20%                             | Valor dos itens * 0,80 + Peso * Valor Frete          |
| Peso > 50               | Valor ≤ 500             | Ouro            | 7                      | 100%                 | 0%                              | Valor dos itens                                |
| Peso > 50               | 500 < Valor ≤ 1000      | Ouro            | 7                      | 100%                 | 10%                             | Valor dos itens * 0,90                        |
| Peso > 50               | Valor > 1000            | Ouro            | 7                      | 100%                 | 20%                             | Valor dos itens * 0,80                        |
| Peso > 50               | Valor ≤ 500             | Prata           | 7                      | 50%                  | 0%                              | Valor dos itens + Peso * (Valor Frete * 0,5)  |
| Peso > 50               | 500 < Valor ≤ 1000      | Prata           | 7                      | 50%                  | 10%                             | Valor dos itens * 0,90 + Peso * (Valor Frete * 0,5)  |
| Peso > 50               | Valor > 1000            | Prata           | 7                      | 50%                  | 20%                             | Valor dos itens * 0,80 + Peso * (Valor Frete * 0,5)  |
| Peso > 50               | Valor ≤ 500             | Bronze          | 7                      | 0%                   | 0%                              | Valor dos itens + Peso * Valor Frete          |
| Peso > 50               | 500 < Valor ≤ 1000      | Bronze          | 7                      | 0%                   | 10%                             | Valor dos itens * 0,90 + Peso * Valor Frete          |
| Peso > 50               | Valor > 1000            | Bronze          | 7                      | 0%                   | 20%                             | Valor dos itens * 0,80 + Peso * Valor Frete          |

### Observações
- O valor do frete depende do peso total e do tipo de cliente.
- O desconto nos itens é aplicado apenas ao valor dos itens e depende do valor total da compra.
- A fórmula final considera o valor dos itens com descontos aplicados e o frete com descontos dependendo do tipo de cliente.
