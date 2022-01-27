using System;

namespace cronos.repository.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IAdministratorRepository AdministratorRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IPostRepository PostRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
    }
}