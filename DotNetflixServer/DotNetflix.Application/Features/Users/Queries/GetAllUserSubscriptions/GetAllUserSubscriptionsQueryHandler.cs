﻿using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;

internal class GetAllUserSubscriptionsQueryHandler : IQueryHandler<GetAllUserSubscriptionsQuery, IEnumerable<GetUserSubscriptionDto>>
{
    private readonly DbContext _dbContext;

    public GetAllUserSubscriptionsQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<GetUserSubscriptionDto>> Handle(GetAllUserSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var userSubscriptions = _dbContext.Set<UserSubscription>()
            .Where(us => us.UserId == request.UserId)
            .Include(s => s.Subscription);

        var result = userSubscriptions
            .Select(us => new GetUserSubscriptionDto(us.Subscription.Id, us.Subscription.Name, us.Subscription.Cost, us.Expires))
            .AsEnumerable();
        return Task.FromResult(result);
    }
}
