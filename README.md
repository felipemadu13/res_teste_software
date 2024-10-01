# Testes de Software - Finalização de Compra em E-commerce

**Disciplina:** Teste de Software <br>
**Professor:** Eiji Adachi

## Descrição do Projeto
Este projeto é parte do trabalho de implementação de testes automatizados para a funcionalidade de finalização de compra em um e-commerce, desenvolvido como parte da disciplina de Testes de Software. A aplicação backend segue a arquitetura API REST, organizada em três camadas: Controller, Service e Repository.


## Instruções para Rodar o Projeto, Testes e Cobertura

### 1. Restaurar Dependências

Execute o comando abaixo na raiz do projeto para restaurar todas as dependências necessárias:

```bash
dotnet restore
```

---

### 2. Compilar o Projeto

Compile o projeto no modo `Debug` para garantir que ele está pronto para execução e teste:

```bash
dotnet build --configuration Debug
```

---

### 3. Rodar o Projeto

Navegue até a pasta do projeto principal (onde o `eCommerce.csproj` está localizado) e execute o comando:

```bash
dotnet run
```

Isso iniciará o projeto. Certifique-se de que a aplicação está funcionando corretamente antes de rodar os testes.

---

### 4. Executar os Testes

Navegue até o diretório do projeto de testes (`eCommerce.Tests`) e execute o comando abaixo para rodar todos os testes:

```bash
dotnet test
```

Isso executará todos os testes no projeto de testes e exibirá o resultado no terminal.

---

### 5. Rodar os Testes com Cobertura de Código

Para executar os testes e coletar a cobertura, utilize o comando abaixo a partir do diretório do projeto de testes:

```bash
dotnet test --collect:"XPlat Code Coverage"
```

Isso gerará um relatório de cobertura de código na pasta `TestResults`.

---

### 6. Gerar Relatório Visual de Cobertura (Opcional)

Use o `ReportGenerator` para converter o relatório em um formato visual como HTML:

Para instalar o ReportGenerator usando dotnet tool, abra o terminal e execute o seguinte comando:  

```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

Depois, execute o comando abaixo:  

```bash
reportgenerator -reports:"./TestResults/**/coverage.cobertura.xml" -targetdir:"./coverage-report" -reporttypes:Html
```

Depois, abra o arquivo `index.html` na pasta `coverage-report` para visualizar o relatório detalhado.

---

### 7. Tabelas de Decisão e Valores Limite

Para ver as Tabelas clique nos Links abaixo:  

[Tabela de Decisão](eCommerce.Tests\tabela_decisao.md)  
[Tabela de Valores Limite](eCommerce.Tests\valor_limite.md)  

