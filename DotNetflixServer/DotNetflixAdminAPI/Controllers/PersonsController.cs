using DotNetflix.Admin.Application.Features.Persons.GetAll;
using DotNetflix.Admin.Application.Features.Persons.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Manager")]
public class PersonsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PersonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<PersonDto>> GetAll()
    {
        return await _mediator.Send(new GetAllPersonsQuery());
    }
}