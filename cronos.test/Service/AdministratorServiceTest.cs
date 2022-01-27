using cronos.entity.Entity;
using cronos.repository.Repository;
using cronos.repository.Repository.Base;
using cronos.service.Service;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace cronos.test
{
    public class AdministratorServiceTest
    {
        private readonly Mock<IAdministratorRepository> _mockAdministratorRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public AdministratorServiceTest()
        {
            _mockAdministratorRepository = new Mock<IAdministratorRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }


        /// <summary>
        /// Teste mockando a AdministratorRepository e verificando se a service está chamando corretamente a InsertAsync.
        /// </summary>        
        [Fact]
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

        /// <summary>
        /// Teste mockando a AdministratorRepository e verificando se a service está chamando corretamente a GetByEmailAndPassword e se o retorno está correto.
        /// </summary>    
        [Fact]
        public async Task Signin__ShouldCallGetByEmailAndPassowrdAdministratorRepository__ReturnValidAdministrator()
        {
            var administrator = new Administrator("test@test.com", "test123");
            var administratorService = new AdministratorService(_mockUnitOfWork.Object);

            _mockAdministratorRepository
              .Setup(administratorRepository => administratorRepository.GetByEmailAndPassword(administrator))
              .ReturnsAsync(administrator);

            _mockUnitOfWork
                .Setup(uow => uow.AdministratorRepository)
                .Returns(_mockAdministratorRepository.Object);

            var administratorTest = await administratorService.SigninAsync(administrator);

            _mockAdministratorRepository.Verify(administratorRepository => administratorRepository.GetByEmailAndPassword(administrator));
            Assert.Equal(administrator.email, administratorTest.email);
            Assert.Equal(administrator.password, administratorTest.password);
        }
    }
}
