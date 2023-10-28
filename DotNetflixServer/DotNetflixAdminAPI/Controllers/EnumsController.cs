using DotNetflix.Admin.Application.Features.Films.Queries.GetAllEnums;
using DotNetflix.Admin.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Manager")]
public class EnumsController : Controller
{
    private readonly IMediator _mediator;

    public EnumsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IDictionary<string, IEnumerable<EnumDto<int>>>> GetAll()
    {
        return await _mediator.Send(new GetAllEnumsQuery());
    }
}