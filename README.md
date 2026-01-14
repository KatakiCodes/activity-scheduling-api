# activity-scheduling-api

Este projeto consiste em uma **API backend simples de sistema de agendamento**, desenvolvida com o objetivo de estudo e demonstração de boas práticas no desenvolvimento de aplicações backend em .NET.

A API permite gerenciar atividades por meio de operações de **agendamento, cancelamento e remarcação**, aplicando regras básicas de negócio e persistência de dados.

O projeto foi pensado para ser evoluído gradualmente, servindo como base para a adição de novos recursos, validações, autenticação, testes e melhorias arquiteturais.

---

## 🛠 Tecnologias Utilizadas

- **.NET (ASP.NET Core Web API)**
- **Entity Framework Core**
- **SQLite** (banco de dados leve para desenvolvimento)
- **C#**
- **RESTful API**

---

## 🎯 Objetivo do Projeto

- Praticar conceitos fundamentais de backend
- Aplicar boas práticas de organização e estruturação de APIs
- Trabalhar com regras de negócio simples
- Servir como base para evolução contínua do projeto

---

## Como Executar o Projeto

1.  **Clone o repositório:**
    ```bash
    git clone https://github.com/katakicodes/activity-scheduling-api.git
    cd activity-scheduling-api
    ```

2.  **Restaure as dependências:**
    Navegue até o diretório `src` e execute o comando `dotnet restore` para baixar todas as dependências do projeto.
    ```bash
    cd src
    dotnet restore
    ```

3.  **Configure o Banco de Dados:**
    Este projeto utiliza o Entity Framework Core para gerenciar o banco de dados. A string de conexão está configurada no arquivo `appsettings.json` para usar um banco de dados em memória (InMemory), então não são necessárias configurações adicionais para um ambiente de desenvolvimento inicial.

    Para ambientes de produção ou se desejar usar um provedor de banco de dados diferente (como SQL Server, PostgreSQL, etc.), você precisará:
    - Instalar o pacote NuGet do provedor de banco de dados desejado.
    - Atualizar a string de conexão em `appsettings.json` e `appsettings.Development.json`.
    - Configurar o provedor no arquivo `src/activity-scheduling.infra.ioc/ConfigureDbContext.cs`.

4.  **Execute as Migrations:**
    Para criar e aplicar as migrations e garantir que o schema do banco de dados esteja atualizado, execute os seguintes comandos a partir do diretório que contém o projeto `activity-scheduling.infra.data`:
    ```bash
    cd activity-scheduling.infra.data
    dotnet ef database update
    ```
    *Observação: Certifique-se de ter o `dotnet ef tools` instalado globalmente (`dotnet tool install --global dotnet-ef`).*

5.  **Execute a Aplicação:**
    Navegue até o diretório do projeto principal da API e execute a aplicação.
    ```bash
    cd ../activity-scheduling-api
    dotnet run
    ```
    A API estará disponível em `https://localhost:5001` ou `http://localhost:5000` (consulte o arquivo `launchSettings.json` para as URLs exatas).
