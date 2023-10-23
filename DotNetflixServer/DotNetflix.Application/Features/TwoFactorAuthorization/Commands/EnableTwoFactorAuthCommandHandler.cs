using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;
using Services.Shared.TwoFactorAuthCodeService;

namespace DotNetflix.Application.Features.TwoFactorAuthorization.Commands;

internal class EnableTwoFactorAuthCommandHandler : ICommandHandler<EnableTwoFactorAuthCommand, Result<string, string>>
{
    private readonly ITwoFactorAuthCodeService _twoFactorAuthCodeService;
    private readonly UserManager<User> _userManager;

    public EnableTwoFactorAuthCommandHandler(ITwoFactorAuthCodeService twoFactorAuthCodeService, UserManager<User> userManager)
    {
        _twoFactorAuthCodeService = twoFactorAuthCodeService;
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(EnableTwoFactorAuthCommand request, CancellationToken cancellationToken)
    {
        if (!_twoFactorAuthCodeService.CheckCode(request.Email, request.Code))
            return new Result<string, string>(failure: "Код не совпадает или устарел");
        
        var enableResult = await _userManager.SetTwoFactorEnabledAsync(request.User, true);
        
        return enableResult.Succeeded
            ? new Result<string, string>(success: "Двухфакторная аутентификация подключена")
            : new Result<string, string>(failure: enableResult.ToString());
    }
}