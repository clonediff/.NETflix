using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Shared.Mapping;
using Microsoft.AspNetCore.Identity;
using Services.Shared.TwoFactorAuthCodeService;

namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

internal class SetUserPasswordCommandHandler : ICommandHandler<SetUserPasswordCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;
    private readonly ITwoFactorAuthCodeService _twoFactorAuthCodeService;

    public SetUserPasswordCommandHandler(UserManager<User> userManager,
        ITwoFactorAuthCodeService twoFactorAuthCodeService)
    {
        _userManager = userManager;
        _twoFactorAuthCodeService = twoFactorAuthCodeService;
    }

    public async Task<Result<string, string>> Handle(SetUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.User);
        if (!_twoFactorAuthCodeService.CheckCode(user!.Email!, request.Code))
            return new Result<string, string>(failure: "Код не совпадает или устарел");
        
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, request.Password);
        var changeRes = await _userManager.UpdateAsync(user);

        return changeRes.ToResult("Пароль изменён");
    }
}
