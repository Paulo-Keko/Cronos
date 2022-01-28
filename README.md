# Introdução CRONOS API
Para este projeto foi usado o dotnet core 5, visando atender os requisitos da documentação envia para a execução do exercício,o projeto foi desenvolvido no Visual Studio 2019, usando como banco relacional o conceito de Generic Repository, em linhas gerais tente executar um projeto bem enxuto, que atendesse rapidamente a solictação da proposta.

<b>Bibliotecas:</b>
- Dapper: Micro orm usado para comunicação com o banco de dados.
- Dapper Contrib: Extensão para a implementação do Generic Repository.
- Fluent Migration: Biblioteca para gestão de migrations dos scripts de banco de dados.
- SQLite: Foi usado o banco de dados SQLite, apesar de suas limitações, atende ao exercício proposto....a ideia era simplificar por conta do uso da base em memória
- Moq: Foi usado como uma biblioteca para mocar objetos para a plataforma . NET desenvolvida para tirar o máximo proveito de recursos como Linq, árvores de expressão, expressões lambdas,
- XUnit:  Foi usado para auxiliar na construção e execução de testes unitários, ou melhor, trechos de códigos construídos para testar partes específicas de determinado sistema

# Documentação API
Toda a documentação da API está disponível pelo [swagger](/swagger/index.html).

# Generic Repository e Unit Of Work
[Unit Of Work](https://www.martinfowler.com/eaaCatalog/unitOfWork.html)
- Unit Of Work é um padrão de projeto e, de acordo com Martin Fowler, o padrão de unidade de trabalho “mantém uma lista de objetos afetados por uma transação, coordena a escrita de mudanças e trata possíveis problemas de concorrência

[Generic Repository](https://www.martinfowler.com/eaaCatalog/repository.html)
- De uma maneira bem simples, Martin Fowler define um repositório como um “objeto que faz a mediação entre o domínio e as camadas de mapeamento de dados”. O objetivo é isolar objetos de domínio dos detalhes do código de acesso a dados. No entanto, o repositório genérico pode permitir que os desenvolvedores envolvam a tecnologia de acesso a dados subjacente, como classes do Entity Framework.

# Unit Test
Para teste unitário, eu procuro isolar a camada de persitência mockando os dados, afim de garantir apenas os testes de negócio da camada de serviço.

Exemplo:

```
public async Task Insert__ShouldCallInsertAsnycAdministratorRepository()
{
    var administrator = new Administrator("test@test.com", "test123");
    var administratorService = new AdministratorService(_mockUnitOfWork.Object);

    _mockAdministratorRepository
        .Setup(administratorRepository => administratorRepository.InsertAsync(administrator));

    _mockUnitOfWork
        .Setup(uow => uow.AdministratorRepository)
        .Returns(_mockAdministratorRepository.Object);           

    await administratorService.InsertAsync(administrator);
    _mockAdministratorRepository.Verify(administratorRepository => administratorRepository.InsertAsync(administrator));
}
```
