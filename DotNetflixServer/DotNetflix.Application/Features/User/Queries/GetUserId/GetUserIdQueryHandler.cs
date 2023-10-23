using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.User.Queries.GetUserId;

internal class GetUserIdQueryHandler : IQueryHandler<GetUserIdQuery, string?>
{
    private readonly UserManager<Domain.Entities.User> _userManager;

    public GetUserIdQueryHandler(UserManager<Domain.Entities.User> userManager)
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
