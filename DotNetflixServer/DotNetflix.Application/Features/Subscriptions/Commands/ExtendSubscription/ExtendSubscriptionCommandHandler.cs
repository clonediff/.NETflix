using DataAccess;
using Domain.Exceptions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;
using Services.Shared.PaymentService;

namespace DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;

internal class ExtendSubscriptionCommandHandler : ICommandHandler<ExtendSubscriptionCommand>
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IPaymentService _paymentService;

    public ExtendSubscriptionCommandHandler(ApplicationDBContext dbContext, IPaymentService paymentService)
    {
        _dbContext = dbContext;
        _paymentService = paymentService;
    }

    public async Task Handle(ExtendSubscriptionCommand request, CancellationToken cancellationToken)
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
            throw new NotFoundException("Не удалось найти подписку");

        if (userSubscription.Expires is null)
            throw new IncorrectOperationException("Нельзя продлевать бессрочные подписки");

        if (!_paymentService.PayByCard(request.CardDataDto, userSubscription.Subscription.Cost))
            throw new IncorrectOperationException(
                "Не удалось продлить данную подписку, так как введены некорректные реквизиты к оплате");

        if (userSubscription.Expires is not null)
            userSubscription.Expires = userSubscription.Expires! + TimeSpan.FromDays(userSubscription.Subscription.PeriodInDays!.Value);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
