﻿using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;

internal class ExtendSubscriptionCommandHandler : ICommandHandler<ExtendSubscriptionCommand, Result<int, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public ExtendSubscriptionCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(ExtendSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var userSubscription = await _dbContext.UserSubscriptions
            .Where(us =>
                us.UserId == request.UserSubscriptionDto.UserId &&
                us.SubscriptionId == request.UserSubscriptionDto.SubscriptionId)
            .Include(us => us.Subscription)
            .FirstOrDefaultAsync(
                us => us.UserId == request.UserSubscriptionDto.UserId &&
                      us.SubscriptionId == request.UserSubscriptionDto.SubscriptionId, cancellationToken);

        if (userSubscription is null)
            return "Не удалось найти подписку";

        if (userSubscription.Expires is null)
            return "Нельзя продлевать бессрочные подписки";

        if (userSubscription.Expires is not null)
            userSubscription.Expires = userSubscription.Expires! + TimeSpan.FromDays(userSubscription.Subscription.PeriodInDays!.Value);

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}