using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Shared.Mapping;
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
