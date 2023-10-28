using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.SetRole;

internal class SetRoleCommandHandler : ICommandHandler<SetRoleCommand, Result<bool, string>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IEmailService _emailService;

    public SetRoleCommandHandler(
        IEmailService emailService,
        ApplicationDBContext dbContext)
    {
        _emailService = emailService;
        _dbContext = dbContext;
    }

    public async Task<Result<bool, string>> Handle(SetRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Roles.AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);

        if (role == null)
            return "Не удалось найти роль";

        var user = await _dbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

        if (user!.BannedUntil != null)
            return "Нельзя менять роль заблокированным пользователям";
        
        var userRoles = await _dbContext.UserRoles
            .Where(x => x.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        _dbContext.UserRoles.RemoveRange(userRoles);
        _dbContext.UserRoles.Add(new IdentityUserRole<string>
        {
            RoleId = request.RoleId,
            UserId = request.UserId,
        });

        await _dbContext.SaveChangesAsync(cancellationToken);

        await _emailService.SendEmailAsync(user.Email!, 
            "Ваша роль обновлена", 
            $"Теперь Вы {role.Name!}.");
        
        return true;
    }
}