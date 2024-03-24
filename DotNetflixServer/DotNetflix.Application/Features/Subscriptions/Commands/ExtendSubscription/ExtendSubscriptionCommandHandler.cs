using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;
using Services.Shared;

namespace DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;

internal class ExtendSubscriptionCommandHandler : ICommandHandler<ExtendSubscriptionCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;
    private readonly PaymentService.PaymentServiceClient _paymentServiceClient;

    public ExtendSubscriptionCommandHandler(
        DbContext dbContext,
        PaymentService.PaymentServiceClient paymentServiceClient)
    {
        _dbContext = dbContext;
        _paymentServiceClient = paymentServiceClient;
    }

    public async Task<Result<int, string>> Handle(ExtendSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var userSubscription = await _dbContext.Set<UserSubscription>()
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

        var cardData = new CardData()
        {
            Cvv = request.CardDataDto.CVV_CVC.ToString(),
            CardHolder = request.CardDataDto.Cardholder,
            Number = request.CardDataDto.CardNumber
        };

        var response = await _paymentServiceClient.PayAsync(cardData, cancellationToken: cancellationToken);

        if (!response.Success) 
            return "Оплата не прошла";
        
        int result;

        try
        {
            result = await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            await _paymentServiceClient.RefundAsync(cardData, cancellationToken: cancellationToken);
            throw;
        }

        return result;
    }
}
