using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.UnbanUser;

internal class UnbanUserCommandHandler : ICommandHandler<UnbanUserCommand, Result<bool, string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public UnbanUserCommandHandler(
        UserManager<User> userManager,
        IEmailService emailService)
    {
        _emailService = emailService;
        _userManager = userManager;
    }

    public async Task<Result<bool, string>> Handle(UnbanUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        
        if (user!.BannedUntil == null)
            return "Нельзя разблокировать уже разблокированного пользователя";

        user.BannedUntil = null;

        await _userManager.UpdateAsync(user);

        await _emailService.SendEmailAsync(user.Email!,
            "Ваш аккаунт был разблокирован",
            "Желаем приятно провести время на нашем сервисе");

        return true;
    }
}