using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using System.Threading.Tasks;

namespace cronos.service.Service
{
    public class AdministratorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdministratorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }  

        public async Task<Administrator> SigninAsync(Administrator administrator)
        {
            using (_unitOfWork)
            {
                administrator = await _unitOfWork.AdministratorRepository.GetByEmailAndPassword(administrator);
            }

            return administrator;
        }

        public async Task<Administrator> InsertAsync(Administrator administrator)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.AdministratorRepository.InsertAsync(administrator);
            }

            return administrator;
        }
    }
}
