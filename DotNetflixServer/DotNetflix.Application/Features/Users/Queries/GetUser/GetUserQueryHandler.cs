using Domain.Entities;
using DotNetflix.Application.Shared;
using DotNetflix.Application.Shared.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Users.Queries.GetUser;

internal class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
{
    private readonly UserManager<User> _userManager;

    public GetUserQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.User);
        return user?.ToUserDto()!;
    }
}
