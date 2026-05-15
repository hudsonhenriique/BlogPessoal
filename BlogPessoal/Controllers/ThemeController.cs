using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Repositories;
using PersonalBlog.Models;

namespace PersonalBlog.Controllers
{
    [Route("api/themes")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeRepository _themeRepository;

        public ThemeController(IThemeRepository themeRepository)
        {
            _themeRepository = themeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _themeRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(long id)
        {
            var theme = await _themeRepository.GetById(id);
            if (theme == null) return NotFound("Tema não encontrado");
            return Ok(theme);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Theme theme)
        {
            var newTime = await _themeRepository.Create(theme);
            return CreatedAtAction(nameof(GetById),new {id = newTime.Id }, newTime);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Theme theme)
        {
            var updateTheme = await _themeRepository.Update(theme);
            if (updateTheme == null) return NotFound("Tema não encontrado para atualizar");
            return Ok(updateTheme);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            await _themeRepository.Delete(id);
            return NoContent();
        }

    }
}