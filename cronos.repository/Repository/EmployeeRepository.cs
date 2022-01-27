using cronos.entity.Entity;
using cronos.repository.Repository.Base;

namespace cronos.repository.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDBContext dbcontext) : base(dbcontext) { }
    }
}
