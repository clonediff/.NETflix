using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;

public class GetAllSubscriptionsForUserQueryHandler : IQueryHandler<GetAllSubscriptionsForUserQuery, IEnumerable<AvailableSubscriptionDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllSubscriptionsForUserQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<AvailableSubscriptionDto>> Handle(GetAllSubscriptionsForUserQuery request, CancellationToken cancellationToken)
    {
        var userSubscriptionIds = Enumerable.Empty<int>();
            
        if (request.UserId is not null)
        {
            userSubscriptionIds = _dbContext.Users
                .Where(u => u.Id == request.UserId)
                .Include(u => u.Subscriptions)
                .SelectMany(u => u.Subscriptions.Select(s => s.Id));
        }

        return Task.FromResult(
            _dbContext.Subscriptions
            .Where(s => s.IsAvailable || userSubscriptionIds.Contains(s.Id))
            .Include(s => s.Movies)
            .Select(s => new AvailableSubscriptionDto(s.Id, s.Name, s.Cost, s.PeriodInDays, userSubscriptionIds.Contains(s.Id), s.Movies.Select(m => m.Name)))
            .AsEnumerable());
    }
}
