﻿using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;
using Services.Shared.PaymentService;

namespace DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;

internal class PurchaseSubscriptionCommandHandler : ICommandHandler<PurchaseSubscriptionCommand, Result<int, string>>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IPaymentService _paymentService;

    public PurchaseSubscriptionCommandHandler(ApplicationDBContext dbContext, IPaymentService paymentService)
    {
        _dbContext = dbContext;
        _paymentService = paymentService;
    }

    public async Task<Result<int, string>> Handle(PurchaseSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription =
            await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == request.UserSubscriptionDto.SubscriptionId,
                cancellationToken);

        if (subscription is null || !subscription.IsAvailable)
            return "Не удалось найти подписку";

        if (_dbContext.UserSubscriptions.Any(us =>
                us.UserId == request.UserSubscriptionDto.UserId &&
                us.SubscriptionId == request.UserSubscriptionDto.SubscriptionId))
            return "Неудалось приобрести данную подписку, так как она уже приобретена";

        if (!_paymentService.PayByCard(request.CardDataDto, subscription.Cost))
            return "Не удалось приобрести данную подписку, так как введены некорректные реквизиты к оплате";

        _dbContext.UserSubscriptions.Add(new UserSubscription
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
