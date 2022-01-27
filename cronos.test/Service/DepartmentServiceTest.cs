using cronos.entity.Entity;
using cronos.repository.Repository;
using cronos.repository.Repository.Base;
using cronos.service.Service;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace cronos.test
{
    public class DepartmentServiceTest
    {
        private readonly Mock<IDepartmentRepository> _mockDepartmentRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public DepartmentServiceTest()
        {
            _mockDepartmentRepository = new Mock<IDepartmentRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        /// <summary>
        /// Teste mockando a DepartmentRepository e verificando se a service está chamando corretamente a DeleteAsync com o modelo correto que deve ser apagado
        /// </summary>        
        [Fact]
        public async Task Delete__ShouldCallDeleteAsyncDepartmentRepository__ValidDepartmentDeleted()
        {
            var deparment = new Department(1, "test");

            _mockDepartmentRepository
                .Setup(departmentRepository => departmentRepository.GetAsync(1))
                .ReturnsAsync(deparment);

            _mockDepartmentRepository
                .Setup(departmentRepository => departmentRepository.DeleteAsync(deparment));            

            _mockUnitOfWork
                .Setup(uow => uow.DepartmentRepository)
                .Returns(_mockDepartmentRepository.Object);
            
            var departmentService = new DepartmentService(_mockUnitOfWork.Object);
            var departmentTest = await departmentService.DeleteAsync(1);

            _mockDepartmentRepository.Verify(departmentRepository => departmentRepository.DeleteAsync(deparment));
            Assert.Equal(deparment.id, departmentTest.id);
        }

        /// <summary>
        /// Teste mockando a DepartmentRepository e verificando se a service está chamando corretamente a GetAllAsync e validando a quantidade da lista retornada
        /// </summary>        
        [Fact]
        public async Task GetAll__ShouldCallGetAllAsyncDepartmentRepository__ReturnValidCount()
        {
            var departments = new List<Department>
            {
                new Department(1, "test"),
                new Department(2, "test"),
                new Department(3, "test")
            };

            _mockDepartmentRepository
              .Setup(departmentRepository => departmentRepository.GetAllAsync())
              .ReturnsAsync(departments);

            _mockUnitOfWork
              .Setup(uow => uow.DepartmentRepository)
              .Returns(_mockDepartmentRepository.Object);

            var departmentService = new DepartmentService(_mockUnitOfWork.Object);
            var departmentsTest = await departmentService.GetAllAsync();

            _mockDepartmentRepository.Verify(departmentRepository => departmentRepository.GetAllAsync());
            Assert.Equal(departments.Count, departmentsTest.Count());
        }
    }
}
