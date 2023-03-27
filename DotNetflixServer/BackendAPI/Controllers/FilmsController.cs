using System.Collections;
using BackendAPI.Dto;
using BackendAPI.Dto.MoviePage;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

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
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(
        [FromQuery] string? type,
        [FromQuery] string? name, 
        [FromQuery] int? year, 
        [FromQuery] string? country,
        [FromQuery(Name = "genre")] string[]? genres,
        [FromQuery(Name = "actor")] string[]? actors,
        [FromQuery] string? director)
    {
        return _filmProvider.GetFilmsBySearch(type, name, year, country, genres, actors, director);
    }

    [HttpGet("/movies")]
    public async Task<MovieForMoviePageDto?> GetFilmById([FromQuery] int id)
    {
        return await _filmProvider.GetFilmByIdAsync(id);
    }
}