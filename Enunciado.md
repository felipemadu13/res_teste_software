# Testes de Software - Prof. Eiji Adachi

**Trabalho**: Implementação de Testes Automatizados para Funcionalidade de Finalização de Compra em um E-commerce  

---

#### Contexto do Trabalho

Você receberá um projeto backend de uma aplicação de e-commerce estruturada como uma **API REST**, organizada em três camadas principais:
- **Controller**: Responsável por lidar com as requisições HTTP.
- **Service**: Contém a lógica de negócio.
- **Repository**: Responsável pela interação com o banco de dados.

Neste trabalho, o foco será implementar **testes automatizados** para a funcionalidade de **finalizar compra**, que faz parte de um processo de checkout em um e-commerce. 

Este trabalho pode ser feito em grupos de 1 a 4 membros.

#### Descrição da Funcionalidade de Finalização de Compra

A funcionalidade de finalizar compra recebe como entradas um identificador para um **cliente** e um identificador para um **carrinho de compras**, que encapsula um conjunto de produtos selecionados pelo cliente. Ela realiza as seguintes operações:

1. **Consulta ao serviço de estoque**: Verifica se há quantidade suficiente de cada produto no estoque.
2. **Cálculo do preço total da compra**: Soma o valor total dos produtos no carrinho e aplica as regras de negócio descritas a seguir.
3. **Consulta ao serviço de pagamentos**: Verifica se o pagamento foi autorizado.
4. **Atualização do estoque**: Se o pagamento for autorizado, dá baixa no estoque, reduzindo a quantidade dos produtos.

Seu objetivo é implementar testes que cubram a funcionalidade de **finalizar compra** de forma isolada e integrada.

#### Objetivos do Trabalho

1. **Testar a Camada de Serviço**:  
   - Implementar testes automatizados para o **método de cálculo do preço total da compra** na camada de serviço.  
   - Aplicar **critérios de testes de caixa preta** (particionamento em classes de equivalência e análise de valor limites) e **caixa branca** (atingir 100% de cobertura de arestas).
   
2. **Testar a Camada de Controller**:
   - Implementar testes para a **camada de controller** da funcionalidade de finalizar compra, verificando o comportamento correto do endpoint HTTP. 
   - Para esses testes, você deverá:
     - **Fazer um test double do tipo fake** para simular o serviço de estoque.
     - **Usar mock objects** para simular o comportamento do serviço de pagamentos.
     - Atingir 100% de cobertura de arestas dos métodos finalizarCompra das classes CompraController e CompraService.

#### Regras para cálculo do custo da compra
O custo de uma compra é composto pelo custo dos produtos e o custo do frete.

O valor do frete é calculado com base no peso total de todos itens comprados: até 5 kg não é cobrado frete; acima de 5 kg e abaixo de 10 kg é cobrado R$ 2,00 por kg; acima de 10 kg e abaixo de 50 kg é cobrado R$ 4,00 por kg; e acima de 50 kg é cobrado R$ 7,00 por kg. Além disso, clientes do tipo Ouro possuem isenção total do valor do frete, do tipo Prata possuem desconto de 50% e do tipo Bronze pagam o valor integral.

Carrinhos de compras que custam mais de R$ 500,00 recebem um desconto de 10% e aqueles que custam mais de R$ 1000,00 recebem 20% de desconto. Vale ressaltar que este desconto é aplicado somente ao valor dos itens, excluindo o valor do frete.

#### Critérios de Avaliação

1. **Correção dos Testes**: Verificar se os testes cobrem adequadamente os diferentes cenários e se validam corretamente o comportamento esperado da aplicação.
2. **Cobertura de Testes**: Avaliar a cobertura de código, em especial nos testes de caixa branca para o cálculo do preço.
3. **Uso Adequado de Fakes e Mocks**: Avaliar o uso de fakes e mocks nos testes da camada de controller, garantindo que as dependências sejam isoladas de forma correta.
4. **Organização e Boas Práticas**: Avaliar a organização do código dos testes, seguindo boas práticas de nomenclatura, estrutura de testes e clareza.

#### Entrega

Os seus objetivos são:
-	Projetar os casos de teste de unidade (funcionalidade de calcular custo da compra) usando os critérios de particionamento em classes de equivalência e análise de valor limites, apresentando a sistematização dos critérios numa tabela de decisão;
-	Implementar a lógica de negócio do método de calcular o custo da compra;
-	Implementar os testes executáveis tanto para os testes de unidade quanto para os testes da camada de controller;
-	Demonstrar a cobertura dos testes projetados inicialmente. Caso não se alcance os 100% de cobertura de arestas, deve-se acrescentar novos testes para que se alcance os 100% de cobertura de arestas. 

Você deverá entregar esta atividade como um projeto nomeado com os nomes dos membros seguindo o padrão nome1-nome2-nome3 (ex.: JoaoSilva-JoseSouza-EijiAdachi). Lembre-se de também alterar o nome do projeto no atributo artifactId do arquivo pom.xml. Este projeto deverá ser compactado em formato .zip e entregue via SIGAA.

É obrigatório um arquivo do tipo README.md descrevendo como executar o projeto, como executar os testes e como verificar a cobertura dos testes. Também é obrigatório o projeto conter um documento (pode ser uma planilha) com todo o projeto dos casos de testes (partições, limites, tabela de decisão, etc).