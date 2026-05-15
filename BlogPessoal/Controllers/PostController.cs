using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Models;
using PersonalBlog.Repositories;

namespace PersonalBlog.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _postRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var post = await _postRepository.GetById(id);
            if (post == null) return NotFound("Postagem não encontrada.");
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Post post)
        {
            var newPost = await _postRepository.Create(post);
            return CreatedAtAction(nameof(GetById), new { id = newPost?.Id }, newPost);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Post post)
        {
            var updatedPost = await _postRepository.Update(post);
            if (updatedPost == null) return NotFound("Postagem não encontrada.");
            return Ok(updatedPost);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _postRepository.Delete(id);
            return NoContent();
        }
    }
}