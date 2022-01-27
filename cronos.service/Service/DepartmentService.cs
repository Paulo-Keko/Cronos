using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cronos.service.Service
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> DeleteAsync(long id)
        {
            Department department;

            using (_unitOfWork)
            {
                department = await _unitOfWork.DepartmentRepository.GetAsync(id);

                if (department == null)
                    return null;

                await _unitOfWork.DepartmentRepository.DeleteAsync(department);
            }

            return department;
        }

        public async Task<Department> GetAsync(long id)
        {
            Department department;

            using (_unitOfWork)
            {
                department = await _unitOfWork.DepartmentRepository.GetAsync(id);
            }

            return department;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            IEnumerable<Department> departments;

            using (_unitOfWork)
            {
                departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            }

            return departments;
        }

        public async Task<Department> InsertAsync(Department department)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.DepartmentRepository.InsertAsync(department);
            }

            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            Department departmentupd;

            using (_unitOfWork)
            {
                departmentupd = await _unitOfWork.DepartmentRepository.GetAsync(department.id);

                if (departmentupd == null)
                    return null;

                departmentupd.Update(department);
                await _unitOfWork.DepartmentRepository.UpdateAsync(departmentupd);
            }

            return departmentupd;
        }
    }
}
