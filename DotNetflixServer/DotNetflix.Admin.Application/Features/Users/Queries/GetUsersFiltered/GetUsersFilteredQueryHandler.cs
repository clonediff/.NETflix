using Domain.Entities;
using Domain.Extensions;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUsersFiltered;

internal class GetUsersFilteredQueryHandler : IQueryHandler<GetUsersFilteredQuery , PaginationDataDto<UserDto>>
{
    private readonly DbContext _dbContext;

    public GetUsersFilteredQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<PaginationDataDto<UserDto>> Handle(GetUsersFilteredQuery request, CancellationToken cancellationToken)
    {
        var filteredUsers = _dbContext.Set<User>().AsNoTracking()
            .Where(x => request.Name == null || x.UserName!.Contains(request.Name));

        var filteredUsersCount = await filteredUsers.CountAsync(cancellationToken);

        var users = filteredUsers
            .Paginate(request.Page, 25)
            .Join(
                _dbContext.Set<IdentityUserRole<string>>(),
                user => user.Id,
                role => role.UserId,
                (user, role) => new UserDto(user.Id, user.UserName!, user.BannedUntil, role.RoleId))
            .AsEnumerable();

        return new PaginationDataDto<UserDto>(users, filteredUsersCount);
    }
}