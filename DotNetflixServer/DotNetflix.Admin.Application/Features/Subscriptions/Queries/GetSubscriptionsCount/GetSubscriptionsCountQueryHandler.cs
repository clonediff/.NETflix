using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsCount;

internal class GetSubscriptionsCountQueryHandler : IQueryHandler<GetSubscriptionsCountQuery, int>
{
    private readonly ApplicationDBContext _dbContext;

    public GetSubscriptionsCountQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> Handle(GetSubscriptionsCountQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Subscriptions.CountAsync(cancellationToken);
    }
}