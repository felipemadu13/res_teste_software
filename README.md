
# Instruções para Rodar o Projeto, Testes e Cobertura

Aqui estão as etapas resumidas em um guia simples para rodar o projeto, executar os testes e medir a cobertura de código.

---

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

```bash
reportgenerator -reports:"./TestResults/**/coverage.cobertura.xml" -targetdir:"./coverage-report" -reporttypes:Html
```

Depois, abra o arquivo `index.html` na pasta `coverage-report` para visualizar o relatório detalhado.

---

Esse guia resume as principais etapas para rodar o projeto, executar os testes e medir a cobertura de código no ambiente .NET.
