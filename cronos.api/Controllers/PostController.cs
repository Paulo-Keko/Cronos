using cronos.entity.Entity;
using cronos.service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cronos.api.Controllers
{
    [Route("post")]
    [Authorize]
    public class PostController : Controller
    {
        private readonly PostService _postService;

        public PostController(PostService postService)
        {
            _postService = postService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.DeleteAsync(id);

            return Ok(post);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetAsync(id);

            return Ok(post);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

        [HttpPost()]
        public async Task<IActionResult> Insert([FromBody] Post post)
        {
            if (post == null)
                return BadRequest();

            await _postService.InsertAsync(post);

            return Ok(post);
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] Post post)
        {
            if (post == null)
                return BadRequest();

            post = await _postService.UpdateAsync(post);

            return Ok(post);
        }
    }
}
