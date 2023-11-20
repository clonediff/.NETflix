using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetAllFilmsInSubscription;

internal class GetAllFilmsInSubscriptionQueryHandler : IQueryHandler<GetAllFilmsInSubscriptionQuery, IEnumerable<GetAllFilmsInSubscriptionDto>>
{
    private readonly DbContext _dbContext;

    public GetAllFilmsInSubscriptionQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<GetAllFilmsInSubscriptionDto>> Handle(GetAllFilmsInSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var films = _dbContext.Set<MovieInfo>()
            .Where(x => request.Name == null || x.Name.Contains(request.Name))
            .Include(m => m.Subscriptions)
            .AsEnumerable()
            .Select(m => new GetAllFilmsInSubscriptionDto(m.Id, m.Name, m.Subscriptions.Exists(s => s.Id == request.SubscriptionId)))
            .OrderByDescending(x => x.IsInSubscription)
            .AsEnumerable();

        return Task.FromResult(films);
    }
}