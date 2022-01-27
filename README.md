# Introdução CRONOS API
Para este projeto foi usado o dotnet core 5, visando atender os requisitos da documentação envia bala balablab

<b>Bibliotecas:</b>
- Dapper: Micro orm usado para comunicação com o banco de dados.
- Dapper Contrib: Extensão para a implementação do Generic Repository.
- Fluent Migration: Biblioteca para gestão de migrations dos scripts de banco de dados.
- SQLite: Foi usado o banco de dados SQLite, apesar de suas limitações, atende ao exercício proposto....a ideia era simplificar por conta do uso da base em memória
- Moq e XUnit: ....

# Documentação API
Toda a documentação da API está disponível pelo [swagger](/swagger/index.html).

# Generic Repository e Unit Of Work
//https://www.martinfowler.com/eaaCatalog/unitOfWork.html
//https://www.martinfowler.com/eaaCatalog/repository.html

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
