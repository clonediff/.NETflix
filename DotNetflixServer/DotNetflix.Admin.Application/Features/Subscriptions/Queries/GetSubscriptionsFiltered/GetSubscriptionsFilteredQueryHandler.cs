using DataAccess;
using Domain.Extensions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Features.Subscriptions.Mapping;
using DotNetflix.Admin.Application.Shared;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;

internal class GetSubscriptionsFilteredQueryHandler : IQueryHandler<GetSubscriptionsFilteredQuery, PaginationDataDto<GetSubscriptionsFilteredDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetSubscriptionsFilteredQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationDataDto<GetSubscriptionsFilteredDto>> Handle(GetSubscriptionsFilteredQuery request, CancellationToken cancellationToken)
    {
        var filteredSubscriptions = _dbContext.Subscriptions
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