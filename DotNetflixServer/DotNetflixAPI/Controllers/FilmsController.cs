using Contracts.Movies;
using Domain.Exceptions;
using DotNetflix.Application.Features.User.Queries.GetUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly IMediator _mediator;

    public FilmsController(IFilmService filmService, IMediator mediator)
    {
        _filmService = filmService;
        _mediator = mediator;
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
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);

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