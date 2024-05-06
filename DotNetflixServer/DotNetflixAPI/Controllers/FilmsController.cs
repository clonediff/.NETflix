using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilmsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IDictionary<string, IEnumerable<MovieForMainPageDto>>> GetAllFilmsAsync()
    {
        var query = new GetAllFilmsQuery();
        var result = await _mediator.Send(query);
        return result;
    }
    
    [HttpGet("[action]")]
    public async Task<IEnumerable<MovieForSearchPageDto>> GetFilmsBySearchAsync([FromQuery] MovieSearchDto dto)
    {
        var query = new GetFilmsBySearchQuery(dto);
        var result = await _mediator.Send(query);
        return result;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetFilmById([FromQuery] int id)
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);

        var getFilmByIdQuery = new GetFilmByIdQuery(id, userId);
        var result = await _mediator.Send(getFilmByIdQuery);
        return result.Match<IActionResult>(
            Ok, 
            BadRequest);
    }
}