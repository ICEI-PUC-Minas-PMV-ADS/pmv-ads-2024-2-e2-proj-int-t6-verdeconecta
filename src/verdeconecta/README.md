## Requisitos
- [Microsoft Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/) : IDE
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) : Banco de dados
- [NuGet](https://www.nuget.org/) : Gerenciador de pacotes

## Execução
* Abrir o projeto verdeconecta.sln dentro de `/src` no Microsoft Visual Studio: Isso abrirá o Workspace do projeto
* Executar `Update-Database` no console do NuGet

## Comandos
### NuGet
- `Add-Migration NomeDaMigracao` Criar uma nova Migration base na nova Model criada.
- `Update-Database` Atualizar o banco de dados para a versão da última Migration.
