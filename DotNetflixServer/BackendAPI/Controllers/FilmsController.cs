using System.Collections;
using DtoLibrary;
using DtoLibrary.MoviePage;
using Microsoft.AspNetCore.Mvc;
using Services.FilmService;
using Services.Mappers;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmProvider _filmProvider;

    public FilmsController(IFilmProvider filmProvider)
    {
        _filmProvider = filmProvider;
    }

    [HttpGet("[action]")]
    public IEnumerable GetALlFilms()
    {
        return _filmProvider.GetAllFilms();
    }
    
    [HttpGet("[action]")]
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch([FromQuery] QueryStringDto dto)
    {
        return _filmProvider.GetFilmsBySearch(dto.Type, dto.Name, dto.Year, dto.Country, dto.Genres, dto.Actors, dto.Director);
    }

    [HttpGet("[action]")]
    public async Task<MovieForMoviePageDto?> GetFilmById([FromQuery] int id)
    {
        return await _filmProvider.GetFilmByIdAsync(id);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> AddFilmAsync([FromBody] FilmInsertDto dto)
    {
        await _filmProvider.AddFilmAsync(dto.ToMovieInfo());
        return Ok();
    }
}