# Estudo de API REST em ASP.NET Core

Projeto realizado como teste para a empresa playmove. Envolve implementação de uma API REST simples em ASP.NET Core, fazendo uso do Swagger, que realiza operações em uma tabela de fornecedores.

O banco de dados escolhido para este projeto foi SQL. Mais especificamente, foi utilizada uma instância de banco SQL Server Express para testar a aplicação.

### _Instruções de inicialização_
Para preparar o ambiente para esta API é necessário:
- Possuir uma conexão com um banco SQL Server.
- Em seguida rodar o script Create.sql contido na pasta Scripts. Ele criará a tabela Fornecedor como requisitado no enunciado do teste.
- Por fim editar a variável "DbPath" em Playmove/appsettings.json. Entre as aspas deve ser colocada a string de conexão do banco SQL utilizado, por exemplo:
-     "Server=localhost\\SQLEXPRESS;Database=fornecedoresDB;Trusted_Connection=True;"
