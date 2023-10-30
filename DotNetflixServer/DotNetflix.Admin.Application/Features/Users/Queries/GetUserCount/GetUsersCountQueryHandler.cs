using DataAccess;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUserCount;

internal class GetUsersCountQueryHandler : IQueryHandler<GetUsersCountQuery, int>
{
    private readonly ApplicationDBContext _dbContext;

    public GetUsersCountQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetUsersCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Users.CountAsync(cancellationToken);
    }
}