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

![Image](https://github.com/user-attachments/assets/b54b52a5-942b-4dfb-9ac0-4d3cb5757d8c)

Tabelas e dados populados

![Image](https://github.com/user-attachments/assets/bf693b10-9ff3-418b-a0bf-f9eedc0e3f3d)

![Image](https://github.com/user-attachments/assets/08409156-481c-40ea-a887-f8360a99b5dc)

![Image](https://github.com/user-attachments/assets/d6ceff77-cb05-49ee-b17c-405752d2b853)


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
