using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Films;
using Contracts.Admin.Films.Details;
using Domain.Exceptions;
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
    public async Task<PaginationDataDto<EnumDto<int>>> GetFilmsFilteredAsync([FromQuery] string? name, [FromQuery] int? page = 1)
    {
        return await _filmService.GetFilmsFilteredAsync(page!.Value, name);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmById([FromQuery] int id)
    {
        try
        {
            var film = await _filmService.GetFilmById(id);
            return Ok(film);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int id)
    {
        try
        {
            await _filmService.DeleteFilmAsync(id);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateFilmDto dto)
    {
        await _filmService.UpdateFilmAsync(dto);

        return Ok();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmDetails([FromQuery] int id)
    {
        try
        {
            var movie = await _filmService.GetFilmDetailsAsync(id);
            return Ok(movie);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}