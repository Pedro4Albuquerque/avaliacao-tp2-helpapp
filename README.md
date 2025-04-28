# 📘 Avaliação Técnica – Clean Architecture + Azure SQL

Este repositório contém minha entrega referente à avaliação técnica baseada no repositório original do professor:  
[https://github.com/victoricoma/avaliacao-tp2-helpapp](https://github.com/victoricoma/avaliacao-tp2-helpapp)

---

## ✅ Objetivo

Implementar os repositórios `Category` e `Product` seguindo os padrões da Clean Architecture, aplicar a migration `Initial` e conectar a aplicação com uma instância de SQL Server no Azure.

---

## 🚀 Funcionalidades implementadas

- [x] Repositórios `CategoryRepository` e `ProductRepository`
- [x] Configurações com `EntityTypeConfiguration` para `CategoryConfiguration` e `ProductConfiguration`
- [x] Injeção de dependência configurada (`DependencyInjectionAPI`)
- [x] Migration `Initial` criada com `HasData()` para popular categoris inicias
- [x] Banco de dados SQL Server local criado
- [x] Migration aplicada com sucesso utilizando `dotnet ef database update`
- [x] Swagger configurada para documentação da API

---
# 🔧 Comandos utilizados
## Criação da migration
dotnet ef migrations add Initial --project Infra.Data --startup-project WebAPI

## Aplicação no banco de dados (Local)
dotnet ef database update --project Infra.Data --startup-project WebAPI


## Aplicação no banco de dados (Azure)
dotnet ef database update --project Infra.Data --startup-project WebAPI

# 🔗 String de conexão (mascarada)

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=HelpAppDb;Trusted-Connection=True;MultipleActiveResultSets=True;"
}

# Ambiente Utilizado
SQL Server Express instalado localmente

Banco de dados nomeado: avaliacao_tp2_pedro_albuquerque

Banco de dados criada autimaticamente via migrations(HellpAppDb)

Autenticação via Windows Authentication(Trusted_Connectin=True)

Desenvolvimento e testes feitos localmente

Migration aplicada com sucesso diretamente do Visual Studio Terminal

# 🖼️ Prints de evidência (opcional)
Insira prints aqui comprovando:

Aplicação bem-sucedida da migration no Azure

Tabelas e dados populados

# 👨‍💻 Dados do aluno
Nome: [Pedro Albuquerque]
Curso: Desenvolvimento de Sistemas – 3º Semestre

Professor: Victor Icoma

Branch da entrega: avaliacao-Pedro4Albuquerque

## 🧱 Estrutura da aplicação

```bash
📦 src
 ┣ 📂 Domain
 ┃ ┣ Entities
 ┃ ┣ Interfaces
 ┣ 📂 Application
 ┣ 📂 Infra
 ┃ ┣ 📂 Data
 ┃ ┃ ┣ 📂 Migrations
 ┃ ┃ ┣ 📂 Repositories
 ┃ ┃ ┗ 📂 EntityConfiguration
 ┗ 📂 WebAPI
 ┃ ┣  Progam.cs
 ┃ ┣  Appsettings.json
