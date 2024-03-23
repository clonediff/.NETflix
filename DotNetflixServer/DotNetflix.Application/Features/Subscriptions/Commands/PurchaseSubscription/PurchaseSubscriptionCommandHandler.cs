using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;
using Services.Shared;

namespace DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;

internal class PurchaseSubscriptionCommandHandler : ICommandHandler<PurchaseSubscriptionCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;
    private readonly PaymentService.PaymentServiceClient _paymentServiceClient;

    public PurchaseSubscriptionCommandHandler(
        DbContext dbContext,
        PaymentService.PaymentServiceClient paymentServiceClient)
    {
        _dbContext = dbContext;
        _paymentServiceClient = paymentServiceClient;
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
            _paymentServiceClient.RefundAsync(cardData, cancellationToken: cancellationToken);
            throw;
        }

        return result;
    }
}
