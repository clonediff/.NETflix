using Domain.Entities;
using DotNetflix.Application.Shared.Mapping;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Users.Commands.SetUserMail;

internal class SetUserMailCommandHandler : ICommandHandler<SetUserMailCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;

    public SetUserMailCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(SetUserMailCommand request, CancellationToken cancellationToken)
    {
        var changeRes = await _userManager.ChangeEmailAsync(request.User, request.Email, request.Token);

        return changeRes.ToResult("Почта изменена");
    }
}
