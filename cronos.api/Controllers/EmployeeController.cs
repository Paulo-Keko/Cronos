using cronos.entity.Entity;
using cronos.service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cronos.api.Controllers
{
    [Route("employee")]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeService.DeleteAsync(id);

            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.GetAsync(id);

            return Ok(employee);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            await _employeeService.InsertAsync(employee);

            return Ok(employee);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();

            employee = await _employeeService.UpdateAsync(employee);

            return Ok(employee);
        }
    }
}
