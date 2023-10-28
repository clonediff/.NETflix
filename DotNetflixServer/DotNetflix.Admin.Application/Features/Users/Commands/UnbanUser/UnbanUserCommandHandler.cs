using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.UnbanUser;

internal class UnbanUserCommandHandler : ICommandHandler<UnbanUserCommand, Result<bool, string>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IEmailService _emailService;

    public UnbanUserCommandHandler(
        ApplicationDBContext dbContext,
        IEmailService emailService)
    {
        _emailService = emailService;
        _dbContext = dbContext;
    }

    public async Task<Result<bool, string>> Handle(UnbanUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        
        if (user.BannedUntil == null)
            return "Нельзя разблокировать уже разблокированного пользователя";

        user.BannedUntil = null;

        await _dbContext.SaveChangesAsync(cancellationToken);

        await _emailService.SendEmailAsync(user.Email!,
            "Ваш аккаунт был разблокирован",
            "Желаем приятно провести время на нашем сервисе");

        return true;
    }
}