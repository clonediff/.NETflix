using System.Collections;
using Contracts;
using Contracts.Movies;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DotNetflixAPI.Controllers;

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
    public IDictionary<string, IEnumerable<MovieForMainPageDto>> GetAllFilms()
    {
        return _filmService.GetAllFilms();
    }
    
    [HttpGet("[action]")]
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch([FromQuery] MovieSearchDto dto)
    {
        return _filmService.GetFilmsBySearch(dto);
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