using cronos.entity.Entity;
using cronos.repository.Repository.Base;

namespace cronos.repository.Repository
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDBContext dbcontext) : base(dbcontext) { }
    }
}
