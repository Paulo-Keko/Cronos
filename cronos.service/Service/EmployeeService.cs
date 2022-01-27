using cronos.entity.Entity;
using cronos.repository.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cronos.service.Service
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Employee> DeleteAsync(long id)
        {
            Employee employee;

            using (_unitOfWork)
            {
                employee = await _unitOfWork.EmployeeRepository.GetAsync(id);

                if (employee == null)
                    return null;

                await _unitOfWork.EmployeeRepository.DeleteAsync(employee);
            }

            return employee;
        }

        public async Task<Employee> GetAsync(long id)
        {
            Employee employee;

            using (_unitOfWork)
            {
                employee = await _unitOfWork.EmployeeRepository.GetAsync(id);
            }

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            IEnumerable<Employee> employees;

            using (_unitOfWork)
            {
                employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            }

            return employees;
        }

        public async Task<Employee> InsertAsync(Employee employee)
        {
            using (_unitOfWork)
            {
                await _unitOfWork.EmployeeRepository.InsertAsync(employee);
            }

            return employee;
        }

        public async Task<Employee> UpdateAsync(Employee employee)
        {
            Employee employeeupd;

            using (_unitOfWork)
            {
                employeeupd = await _unitOfWork.EmployeeRepository.GetAsync(employee.id);

                if (employeeupd == null)
                    return null;

                employeeupd.Update(employee);
                await _unitOfWork.EmployeeRepository.UpdateAsync(employeeupd);
            }

            return employeeupd;
        }
    }
}
