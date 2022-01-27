using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using System.Threading.Tasks;

namespace cronos.repository.Repository
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Task<Administrator> GetByEmailAndPassword(Administrator administrator);
    }
}