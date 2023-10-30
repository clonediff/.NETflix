using Domain.Entities;
using DotNetflix.Application.Shared.Mapping;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

internal class SetUserPasswordCommandHandler : ICommandHandler<SetUserPasswordCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;

    public SetUserPasswordCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(SetUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var changeRes = await _userManager.ResetPasswordAsync(request.User, request.Token, request.Password);

        return changeRes.ToResult("Пароль изменён");
    }
}
