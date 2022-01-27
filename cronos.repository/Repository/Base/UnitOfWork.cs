using System;

namespace cronos.repository.Repository.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBContext _dbcontext;

        public UnitOfWork(IDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        private IAdministratorRepository _administratorRepository;
        private IEmployeeRepository _employeeRepository;
        private IPostRepository _postRepository;
        private IDepartmentRepository _departmentRepository;

        public IAdministratorRepository AdministratorRepository => GetInstance<IAdministratorRepository, AdministratorRepository>(ref _administratorRepository, _dbcontext);
        public IEmployeeRepository EmployeeRepository => GetInstance<IEmployeeRepository, EmployeeRepository>(ref _employeeRepository, _dbcontext);
        public IPostRepository PostRepository => GetInstance<IPostRepository, PostRepository>(ref _postRepository, _dbcontext);
        public IDepartmentRepository DepartmentRepository => GetInstance<IDepartmentRepository, DepartmentRepository>(ref _departmentRepository, _dbcontext);

        public void Dispose() => _dbcontext.Dispose();

        private static T GetInstance<T, U>(ref T repository, IDBContext dbcontext)
        {
            if (repository == null)
                repository = (T)Activator.CreateInstance(typeof(U), dbcontext);

            return repository;
        }
    }
}
