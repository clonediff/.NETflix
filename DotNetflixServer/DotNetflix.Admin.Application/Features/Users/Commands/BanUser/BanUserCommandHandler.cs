using DataAccess;
using Domain.Exceptions;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.BanUser;

internal class BanUserCommandHandler : ICommandHandler<BanUserCommand, Result<DateTime,string>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IEmailService _emailService;

    public BanUserCommandHandler(
        ApplicationDBContext dbContext,
        IEmailService emailService)
    {
        _emailService = emailService;
        _dbContext = dbContext;
    }

    public async Task<Result<DateTime,string>> Handle(BanUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user!.BannedUntil != null)
            return "Нельзя заблокировать уже заблокированного пользователя";

        user.BannedUntil = DateTime.Now.Add(TimeSpan.FromDays(request.Days));

        await _dbContext.SaveChangesAsync(cancellationToken);

        await _emailService.SendEmailAsync(user.Email!, 
            "Ваш аккаунт был заблокирован", 
            $"Дата автоматической разблокировки {user.BannedUntil:d}.");
        
        return user.BannedUntil.Value;
    }
}