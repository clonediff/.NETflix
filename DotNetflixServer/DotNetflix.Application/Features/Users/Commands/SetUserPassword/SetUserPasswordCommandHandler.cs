using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Shared.Mapping;
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
        request.User.PasswordHash = _userManager.PasswordHasher.HashPassword(request.User, request.Password);
        var changeRes = await _userManager.UpdateAsync(request.User);

        return changeRes.ToResult("Пароль изменён");
    }
}
