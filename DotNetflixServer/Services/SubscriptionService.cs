using Contracts;
using Contracts.Subscriptions;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;

namespace Services;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IPaymentService _paymentService;

    public SubscriptionService(ApplicationDBContext dbContext, IPaymentService paymentService)
    {
        _dbContext = dbContext;
        _paymentService = paymentService;
    }

    public async IAsyncEnumerable<string> GetAllFilmNames(int subscriptionId)
    {
        var subscription = await _dbContext.Subscriptions
            .Where(s => s.Id == subscriptionId)
            .Include(s => s.Movies)
            .FirstOrDefaultAsync(s => s.Id == subscriptionId);
        
        if (subscription is null || !subscription.IsAvailable)
            throw new NotFoundException("Не удалось найти подписку");

        foreach (var movie in subscription.Movies)
        {
            yield return movie.Name;
        }
    }

    public IEnumerable<AvailableSubscriptionDto> GetAllSubscriptions(string? userId)
    {
        var userSubscriptionIds = Enumerable.Empty<int>();
            
        if (userId is not null)
        {
            userSubscriptionIds = _dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Subscriptions)
                .SelectMany(u => u.Subscriptions.Select(s => s.Id));
        }

        return _dbContext.Subscriptions
            .Where(s => s.IsAvailable || userSubscriptionIds.Contains(s.Id))
            .Include(s => s.Movies)
            .Select(s => new AvailableSubscriptionDto(s.Id, s.Name, s.Cost, s.PeriodInDays, userSubscriptionIds.Contains(s.Id), s.Movies.Select(m => m.Name)))
            .AsEnumerable();
    }

    public async Task PurchaseSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == userSubscriptionDto.SubscriptionId);

        if (subscription is null || !subscription.IsAvailable)
            throw new NotFoundException("Не удалось найти подписку");

        if (_dbContext.UserSubscriptions.Any(us => us.UserId == userSubscriptionDto.UserId && us.SubscriptionId == userSubscriptionDto.SubscriptionId))
            throw new IncorrectOperationException("Неудалось приобрести данную подписку, так как она уже приобретена");
        
        if (!_paymentService.PayByCard(cardDataDto, subscription.Cost))
            throw new IncorrectOperationException("Не удалось приобрести данную подписку, так как введены некорректные реквизиты к оплате");

        _dbContext.UserSubscriptions.Add(new UserSubscription
        {
            UserId = userSubscriptionDto.UserId,
            SubscriptionId = userSubscriptionDto.SubscriptionId,
            Expires = subscription.PeriodInDays is null
                ? null
                : DateTime.Now.AddDays(subscription.PeriodInDays.Value)
        });
        
        await _dbContext.SaveChangesAsync();
    }

    public async Task ExtendSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto)
    {
        var userSubscription = await _dbContext.UserSubscriptions
            .Where(us => us.UserId == userSubscriptionDto.UserId && us.SubscriptionId == userSubscriptionDto.SubscriptionId)
            .Include(us => us.Subscription)
            .FirstOrDefaultAsync(us => us.UserId == userSubscriptionDto.UserId && us.SubscriptionId == userSubscriptionDto.SubscriptionId);
        
        if (userSubscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        if (userSubscription.Expires is null)
            throw new IncorrectOperationException("Нельзя продлевать бессрочные подписки");
        
        if (!_paymentService.PayByCard(cardDataDto, userSubscription.Subscription.Cost))
            throw new IncorrectOperationException("Не удалось продлить данную подписку, так как введены некорректные реквизиты к оплате");

        userSubscription.Expires += TimeSpan.FromDays(userSubscription.Subscription.PeriodInDays!.Value);

        await _dbContext.SaveChangesAsync();
    }
}