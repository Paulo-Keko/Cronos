using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using Dapper;
using System.Linq;
using System.Threading.Tasks;

namespace cronos.repository.Repository
{
    public class AdministratorRepository : Repository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(IDBContext dbcontext) : base(dbcontext) { }

        public async Task<Administrator> GetByEmailAndPassword(Administrator administrator)
        {
            var res = await _dbcontext.connection.QueryAsync<Administrator>(@"select * from Administrator where email=@email and password=@password", param: new { administrator.email, administrator.password });
            return res.FirstOrDefault();
        }
    }
}
