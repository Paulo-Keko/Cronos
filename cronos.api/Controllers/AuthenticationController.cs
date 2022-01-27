using cronos.api.Extensions;
using cronos.entity.Entity;
using cronos.service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cronos.api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : Controller
    {
        private readonly AdministratorService _administratorService;

        public AuthenticationController(AdministratorService administratorService)
        {
            _administratorService = administratorService;
        }

        [HttpPost("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin([FromBody]Administrator administrator)
        {
            if (administrator == null)
                return BadRequest();

            administrator = await _administratorService.SigninAsync(administrator);

            if (administrator == null)
                return Unauthorized();

            var token = Token.Generate(administrator);

            return Ok(new { token });
        }

        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> Add([FromBody]Administrator administrator)
        {
            if (administrator == null)
                return BadRequest();

            await _administratorService.InsertAsync(administrator);

            return Ok(administrator);
        }
    }
}
