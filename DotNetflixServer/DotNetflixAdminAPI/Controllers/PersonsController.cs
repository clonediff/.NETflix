using Contracts.Admin.Films;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonsController : ControllerBase
{
    private readonly IFilmPersonService _filmPersonService;

    public PersonsController(IFilmPersonService filmPersonService)
    {
        _filmPersonService = filmPersonService;
    }

    [HttpGet("[action]")]
    public IEnumerable<PersonDto> GetAll()
    {
        return _filmPersonService.GetAll();
    }
}