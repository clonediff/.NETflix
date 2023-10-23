using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Shared.Mapping;
using Microsoft.AspNetCore.Identity;
using Services.Shared.TwoFactorAuthCodeService;

namespace DotNetflix.Application.Features.Users.Commands.SetUserMail;

internal class SetUserMailCommandHandler : ICommandHandler<SetUserMailCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;
    private readonly ITwoFactorAuthCodeService _twoFactorAuthCodeService;

    public SetUserMailCommandHandler(UserManager<User> userManager, ITwoFactorAuthCodeService twoFactorAuthCodeService)
    {
        _userManager = userManager;
        _twoFactorAuthCodeService = twoFactorAuthCodeService;
    }

    public async Task<Result<string, string>> Handle(SetUserMailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.User);
        if (!_twoFactorAuthCodeService.CheckCode(user!.Email!, request.Code))
            return new Result<string, string>(failure: "Код не совпадает или устарел");

        var changeRes = await _userManager.SetEmailAsync(user, request.Email);

        return changeRes.ToResult("Почта изменена");
    }
}
