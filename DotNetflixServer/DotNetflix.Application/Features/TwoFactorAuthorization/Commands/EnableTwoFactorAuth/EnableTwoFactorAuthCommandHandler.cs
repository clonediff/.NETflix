using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.TwoFactorAuthorization.Commands.EnableTwoFactorAuth;

internal class EnableTwoFactorAuthCommandHandler : ICommandHandler<EnableTwoFactorAuthCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;

    public EnableTwoFactorAuthCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(EnableTwoFactorAuthCommand request, CancellationToken cancellationToken)
    {
        var enableResult = await _userManager.ConfirmEmailAsync(request.User, request.Token);
        
        return enableResult.Succeeded
            ? new Result<string, string>(success: "Двухфакторная аутентификация подключена")
            : new Result<string, string>(failure: enableResult.ToString());
    }
}
