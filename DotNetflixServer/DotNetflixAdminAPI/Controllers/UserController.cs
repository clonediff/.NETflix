using DotNetflix.Admin.Application.Features.Users.Commands.BanUser;
using DotNetflix.Admin.Application.Features.Users.Commands.SetRole;
using DotNetflix.Admin.Application.Features.Users.Commands.UnbanUser;
using DotNetflix.Admin.Application.Features.Users.Mapping;
using DotNetflix.Admin.Application.Features.Users.Queries.GetAllRoles;
using DotNetflix.Admin.Application.Features.Users.Queries.GetUserCount;
using DotNetflix.Admin.Application.Features.Users.Queries.GetUsersFiltered;
using DotNetflix.Admin.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<int> GetUsersCountAsync()
        {
            return await _mediator.Send(new GetUsersCountQuery());
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<EnumDto<string>>> GetAllRoles()
        {
            return await _mediator.Send(new GetAllRolesQuery());
        }

        [HttpGet("[action]")]
        public async Task<PaginationDataDto<UserDto>> GetUsers([FromQuery] string? name, [FromQuery] int? page = 1)
        {
            return await _mediator.Send(new GetUsersFilteredQuery(name, page!.Value));
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> SetRoleAsync([FromBody] SetRoleDto setRoleDto)
        {
            var result = await _mediator.Send(setRoleDto.ToSetRoleCommand());

            return result.Match<IActionResult>(
                success: _ => Ok(),
                failure: BadRequest);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> BanUserAsync([FromBody] BanUserDto banUserDto)
        {
            var result = await _mediator.Send(banUserDto.ToBanUserCommand());

            return result.Match<IActionResult>(
                success: x => Ok(x.ToString("d")),
                failure: BadRequest);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UnbanUserAsync([FromBody] string userId)
        {
            var result = await _mediator.Send(new UnbanUserCommand(userId));

            return result.Match<IActionResult>(
                success: _ => Ok(),
                failure: BadRequest);
        }
    }
}