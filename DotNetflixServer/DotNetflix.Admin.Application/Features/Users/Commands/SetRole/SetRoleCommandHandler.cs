using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Infrastructure.EmailService;

namespace DotNetflix.Admin.Application.Features.Users.Commands.SetRole;

internal class SetRoleCommandHandler : ICommandHandler<SetRoleCommand, Result<bool, string>>
{
    private readonly DbContext _dbContext;
    private readonly IEmailService _emailService;
    private readonly UserManager<User> _userManager;

    public SetRoleCommandHandler(
        IEmailService emailService,
        DbContext dbContext,
        UserManager<User> userManager)
    {
        _userManager = userManager;
        _emailService = emailService;
        _dbContext = dbContext;
    }

    public async Task<Result<bool, string>> Handle(SetRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _dbContext.Set<IdentityRole>().AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);

        if (role == null)
            return "Не удалось найти роль";

        var user = await _userManager.FindByIdAsync(request.UserId);

        if (user!.BannedUntil != null)
            return "Нельзя менять роль заблокированным пользователям";
        
        var userRoles = await _dbContext.Set<IdentityUserRole<string>>()
            .Where(x => x.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        _dbContext.Set<IdentityUserRole<string>>().RemoveRange(userRoles);
        _dbContext.Set<IdentityUserRole<string>>().Add(new IdentityUserRole<string>
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