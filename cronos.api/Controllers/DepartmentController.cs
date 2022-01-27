using cronos.entity.Entity;
using cronos.service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cronos.api.Controllers
{
    [Route("service")]
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentService.DeleteAsync(id);

            return Ok(department);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var department = await _departmentService.GetAsync(id);

            return Ok(department);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllAsync();

            return Ok(departments);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody]Department department)
        {
            if (department == null)
                return BadRequest();

            await _departmentService.InsertAsync(department);

            return Ok(department);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Department department)
        {
            if (department == null)
                return BadRequest();

            department = await _departmentService.UpdateAsync(department);

            return Ok(department);
        }
    }
}
