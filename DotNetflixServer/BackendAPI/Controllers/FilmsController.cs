using System.Collections;
using DtoLibrary;
using DtoLibrary.MoviePage;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.FilmService;
using Services.SubscriptionService;
using Services.UserService;

namespace BackendAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;
    private readonly ISubscriptionService _subscriptionService;
    private readonly IUserService _userService;

    public FilmsController(IFilmService filmService, ISubscriptionService subscriptionService, IUserService userService)
    {
        _filmService = filmService;
        _subscriptionService = subscriptionService;
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
    public async Task<ActionResult<MovieForMoviePageDto?>> GetFilmById([FromQuery] int id)
    {
        try
        {
            var user = await _userService.GetUserAsync(User);   
            var userSubscriptions = await _subscriptionService.GetAllSubscriptionsAsync(user.Id);
            var film = await _filmService.GetFilmByIdAsync(id);

            if (_subscriptionService.HaveCommonSubscriptions(userSubscriptions, film!.Subscriptions))
            {
                return Ok(film);
            }
            
            return BadRequest("Оформите подписку, чтобы получить доступ к данному контенту");
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}