# FleetManagerWebApp 🚗

Este é um sistema de gerenciamento de frota (Fleet Manager) desenvolvido com ASP.NET Core MVC e Entity Framework Core. Ele permite o cadastro, edição, listagem e exclusão de veículos, incluindo atributos como tipo, cor, número de passageiros e identificação de chassi (série e número).

## 📸 Imagens da Interface

Veja abaixo uma prévia da interface do sistema:

(Images/PMConsole.jpg)

## ⚙️ Funcionalidades principais

- Cadastro de novos veículos
- Edição de informações
- Exclusão com confirmação
- Interface estilizada com Bootstrap 5
- Validações de formulário
- Layout responsivo

## 🛠️ Requisitos

- .NET SDK 6 ou superior
- SQL Server LocalDB (ou outro banco configurado)
- Visual Studio ou VS Code

## 🧩 Como aplicar as migrações e atualizar o banco de dados

Antes de rodar o projeto, é necessário garantir que o banco de dados está atualizado com a estrutura mais recente. Para isso:

1. Abra o terminal na pasta raiz do projeto (onde está o arquivo `.csproj`).
2. Execute os seguintes comandos:

```bash
# Para adicionar uma nova migration (se necessário)
dotnet ef migrations add NomeDaMigration

# Para aplicar as migrations ao banco de dados
dotnet ef database update