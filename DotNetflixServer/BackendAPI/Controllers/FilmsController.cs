using System.Collections;
using DtoLibrary;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.FilmService;
using Services.UserService;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly IUserService _userService;

    public FilmsController(IFilmService filmService, IUserService userService)
    {
        _filmService = filmService;
        _userService = userService;
    }

    [HttpGet("[action]")]
    public IEnumerable GetAllFilms()
    {
        return _filmService.GetAllFilms();
    }
    
    [HttpGet("[action]")]
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch([FromQuery] QueryStringDto dto)
    {
        return _filmService.GetFilmsBySearch(dto.Type, dto.Name, dto.Year, dto.Country, dto.Genres, dto.Actors, dto.Director);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmById([FromQuery] int id)
    {
        var userId = await _userService.GetUserIdAsync(User);

        try
        {
            var movie = await _filmService.GetFilmByIdAsync(id, userId);
            return Ok(movie);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (IncorrectOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}