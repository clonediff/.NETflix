using AdminBackendAPI.Dto;
using DtoLibrary;
using Microsoft.AspNetCore.Mvc;
using Services.FilmService;
using Services.Mappers;

namespace AdminBackendAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpGet("[action]")]
        public async Task<int> GetFilmsCountAsync()
        {
            return await _filmService.GetFilmsCountAsync();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddFilmAsync([FromBody] FilmInsertDto dto)
        {
            await _filmService.AddFilmAsync(dto.ToMovieInfo());
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<PaginationDataDto<string>> GetAllNames([FromQuery] string? name, [FromQuery] int? page = 1)
        {
            return await _filmService.GetFilmsFilteredAsync(page!.Value, name);
        }
    }
}
