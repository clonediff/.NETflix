using Domain.Entities;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.BanUser;

internal class BanUserCommandHandler : ICommandHandler<BanUserCommand, Result<DateTime,string>>
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailService _emailService;

    public BanUserCommandHandler(
        UserManager<User> userManager,
        IEmailService emailService)
    {
        _emailService = emailService;
        _userManager = userManager;
    }

    public async Task<Result<DateTime,string>> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user!.BannedUntil != null)
            return "Нельзя заблокировать уже заблокированного пользователя";

        user.BannedUntil = DateTime.Now.Add(TimeSpan.FromDays(request.Days));

        await _userManager.UpdateAsync(user);

        await _emailService.SendEmailAsync(user.Email!, 
            "Ваш аккаунт был заблокирован", 
            $"Дата автоматической разблокировки {user.BannedUntil:d}.");
        
        return user.BannedUntil.Value;
    }
}