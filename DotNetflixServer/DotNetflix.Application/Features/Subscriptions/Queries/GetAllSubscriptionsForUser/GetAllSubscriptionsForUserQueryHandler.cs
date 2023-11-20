using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;

internal class GetAllSubscriptionsForUserQueryHandler : IQueryHandler<GetAllSubscriptionsForUserQuery, IEnumerable<AvailableSubscriptionDto>>
{
    private readonly DbContext _dbContext;

    public GetAllSubscriptionsForUserQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<AvailableSubscriptionDto>> Handle(GetAllSubscriptionsForUserQuery request, CancellationToken cancellationToken)
    {
        var userSubscriptionIds = Enumerable.Empty<int>();
            
        if (request.UserId is not null)
        {
            userSubscriptionIds = _dbContext.Set<User>()
                .Where(u => u.Id == request.UserId)
                .Include(u => u.Subscriptions)
                .SelectMany(u => u.Subscriptions.Select(s => s.Id));
        }

        return Task.FromResult(
            _dbContext.Set<Subscription>()
                .Where(s => s.IsAvailable || userSubscriptionIds.Contains(s.Id))
                .Include(s => s.Movies)
                .Select(s => new AvailableSubscriptionDto(s.Id, s.Name, s.Cost, s.PeriodInDays, userSubscriptionIds.Contains(s.Id), s.Movies.Select(m => m.Name)))
                .AsEnumerable());
    }
}
