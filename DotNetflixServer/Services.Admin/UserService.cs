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
}