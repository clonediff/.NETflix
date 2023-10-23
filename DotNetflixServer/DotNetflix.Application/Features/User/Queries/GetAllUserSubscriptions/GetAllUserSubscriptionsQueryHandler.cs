using DataAccess;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.User.Queries.GetAllUserSubscriptions;

internal class GetAllUserSubscriptionsQueryHandler : IQueryHandler<GetAllUserSubscriptionsQuery, IEnumerable<GetUserSubscriptionDto>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllUserSubscriptionsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<GetUserSubscriptionDto>> Handle(GetAllUserSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var userSubscriptions = _dbContext.UserSubscriptions
            .Where(us => us.UserId == request.UserId)
            .Include(s => s.Subscription);

        var result = userSubscriptions
            .Select(us => new GetUserSubscriptionDto(us.Subscription.Id, us.Subscription.Name, us.Subscription.Cost, us.Expires))
            .AsEnumerable();
        return Task.FromResult(result);
    }
}
