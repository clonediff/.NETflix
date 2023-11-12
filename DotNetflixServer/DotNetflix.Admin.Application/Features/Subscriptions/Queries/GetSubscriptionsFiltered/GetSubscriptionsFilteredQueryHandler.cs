using Domain.Entities;
using Domain.Extensions;
using DotNetflix.Admin.Application.Features.Subscriptions.Mapping;
using DotNetflix.Admin.Application.Shared;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

internal class GetSubscriptionsFilteredQueryHandler : IQueryHandler<GetSubscriptionsFilteredQuery, PaginationDataDto<GetSubscriptionsFilteredDto>>
{
    private readonly DbContext _dbContext;

    public GetSubscriptionsFilteredQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationDataDto<GetSubscriptionsFilteredDto>> Handle(GetSubscriptionsFilteredQuery request, CancellationToken cancellationToken)
    {
        var filteredSubscriptions = _dbContext.Set<Subscription>()
            .Where(x => request.Name == null || x.Name.Contains(request.Name))
            .Include(s => s.Users);
        
        var filteredSubscriptionsCount = await filteredSubscriptions.CountAsync(cancellationToken);
        
        var subscriptions = await filteredSubscriptions
            .Paginate(request.Page, request.PageSize)
            .ToListAsync(cancellationToken);

        return new PaginationDataDto<GetSubscriptionsFilteredDto>(
            subscriptions.Select(x => x.ToGetSubscriptionsFilteredDto()), 
            filteredSubscriptionsCount);
    }
}