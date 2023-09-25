using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Users;
using DataAccess;
using Domain.Exceptions;
using Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Admin.Abstractions;

namespace Services.Admin;

public class UserService : IUserService
{
    private readonly ApplicationDBContext _dbContext;

    public UserService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await _dbContext.Users.CountAsync();
    }

    public IEnumerable<EnumDto<string>> GetAllRoles()
    {
        return _dbContext.Roles
            .AsNoTracking()
            .Select(r => new EnumDto<string>(r.Id, r.Name!))
            .AsEnumerable();
    }

    public async Task<PaginationDataDto<UserDto>> GetUsersFilteredAsync(int page, string? name)
    {
        var filteredUsers = _dbContext.Users
            .Where(x => name == null || x.UserName!.Contains(name));

        var filteredUsersCount = await filteredUsers.CountAsync();

        var users = filteredUsers
            .Paginate(page, 25)
            .Join(
                _dbContext.UserRoles,
                user => user.Id,
                role => role.UserId,
                (user, role) => new UserDto(user.Id, user.UserName!, user.BannedUntil, role.RoleId))
            .AsEnumerable();

        return new PaginationDataDto<UserDto>(users, filteredUsersCount);
    }

    public async Task<string> SetRoleAsync(SetRoleDto dto)
    {
        var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == dto.RoleId);
        
        if (role == null)
            throw new NotFoundException("Не удалось найти роль");

        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        if (user.BannedUntil != null)
            throw new IncorrectOperationException("Нельзя менять роль заблокированным пользователям");

        var userRoles = _dbContext.UserRoles
            .Where(x => x.UserId == dto.UserId)
            .AsEnumerable();
        
        _dbContext.UserRoles.RemoveRange(userRoles);

        await _dbContext.UserRoles.AddAsync(new IdentityUserRole<string> 
        { 
            RoleId = dto.RoleId,
            UserId = dto.UserId,
        });

        await _dbContext.SaveChangesAsync();

        return role.Name!;
    }

    public async Task<string> GetEmailAsync(string userId)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");
        
        return user.Email!;
    }

    public async Task<DateTime> BanUserAsync(BanUserDto dto)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == dto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        if (user.BannedUntil != null)
            throw new IncorrectOperationException("Нельзя заблокировать уже заблокированного пользователя");

        user.BannedUntil = DateTime.Now.Add(TimeSpan.FromDays(dto.Days));
        
        await _dbContext.SaveChangesAsync();

        return user.BannedUntil.Value;
    }

    public async Task UnbanUserAsync(string userId)
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.Id == userId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        if (user.BannedUntil == null)
            throw new IncorrectOperationException("Нельзя разблокировать уже разблокированного пользователя");

        user.BannedUntil = null;
        
        await _dbContext.SaveChangesAsync();
    }
}