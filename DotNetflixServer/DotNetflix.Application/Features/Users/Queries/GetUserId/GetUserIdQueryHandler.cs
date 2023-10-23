using Domain.Entities;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Users.Queries.GetUserId;

internal class GetUserIdQueryHandler : IQueryHandler<GetUserIdQuery, string?>
{
    private readonly UserManager<User> _userManager;

    public GetUserIdQueryHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string?> Handle(GetUserIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.ClaimsPrincipal);
        return user is null 
            ? null 
            : await _userManager.GetUserIdAsync(user);
    }
}
