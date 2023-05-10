using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;

namespace DotNetflixAdminAPI.Controllers;

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
    public async Task<IActionResult> AddFilmAsync([FromBody] AddFilmDto dto)
    {
        await _filmService.AddFilmAsync(dto);
        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<PaginationDataDto<string>> GetAllNames([FromQuery] string? name, [FromQuery] int? page = 1)
    {
        return await _filmService.GetFilmsFilteredAsync(page!.Value, name);
    }
}