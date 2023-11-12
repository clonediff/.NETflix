﻿using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;

internal class PurchaseSubscriptionCommandHandler : ICommandHandler<PurchaseSubscriptionCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;

    public PurchaseSubscriptionCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(PurchaseSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription =
            await _dbContext.Set<Subscription>().FirstOrDefaultAsync(x => x.Id == request.UserSubscriptionDto.SubscriptionId,
                cancellationToken);

        if (subscription is null || !subscription.IsAvailable)
            return "Не удалось найти подписку";

        if (_dbContext.Set<UserSubscription>().Any(us =>
                us.UserId == request.UserSubscriptionDto.UserId &&
                us.SubscriptionId == request.UserSubscriptionDto.SubscriptionId))
            return "Не удалось приобрести данную подписку, так как она уже приобретена";

        _dbContext.Set<UserSubscription>().Add(new UserSubscription
        {
            UserId = request.UserSubscriptionDto.UserId,
            SubscriptionId = request.UserSubscriptionDto.SubscriptionId,
            Expires = subscription.PeriodInDays is null
                ? null
                : DateTime.Now.AddDays(subscription.PeriodInDays.Value)
        });

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
