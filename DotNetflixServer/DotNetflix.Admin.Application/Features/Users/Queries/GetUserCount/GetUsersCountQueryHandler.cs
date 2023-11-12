using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUserCount;

internal class GetUsersCountQueryHandler : IQueryHandler<GetUsersCountQuery, int>
{
    private readonly DbContext _dbContext;

    public GetUsersCountQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<User>().CountAsync(cancellationToken);
    }
}