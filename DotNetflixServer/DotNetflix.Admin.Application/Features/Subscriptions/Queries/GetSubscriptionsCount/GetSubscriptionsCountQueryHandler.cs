using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsCount;

internal class GetSubscriptionsCountQueryHandler : IQueryHandler<GetSubscriptionsCountQuery, int>
{
    private readonly DbContext _dbContext;

    public GetSubscriptionsCountQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetSubscriptionsCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Subscription>().CountAsync(cancellationToken);
    }
}