using AdminBackendAPI.Dto;
using Microsoft.AspNetCore.Mvc;
using Services.FilmService;
using Services.Mappers;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmProvider _filmProvider;

        public FilmsController(IFilmProvider filmProvider)
        {
            _filmProvider = filmProvider;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddFilmAsync([FromBody] FilmInsertDto dto)
        {
            await _filmProvider.AddFilmAsync(dto.ToMovieInfo());
            return Ok();
        }

        [HttpGet("[action]")]
        public IEnumerable<string> GetAllNames()
        {
            return _filmProvider.GetAllNames();
        }
    }
}
