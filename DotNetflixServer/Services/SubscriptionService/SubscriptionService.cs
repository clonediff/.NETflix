using DataAccess;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;

namespace Services.SubscriptionService;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationDBContext _dbContext;

    public SubscriptionService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<string>> GetAllSubscriptionsAsync(string userId)
    {
        var user = await _dbContext.Users
            .Include(x => x.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == userId);

        return user!.Subscriptions
            .Select(s => s.Name)
            .ToList();
    }

    public bool HaveCommonSubscriptions(List<string> userSubscriptions, List<string> filmSubscriptions)
    {
        return filmSubscriptions.Count == 0 ||
               userSubscriptions.Count != 0 &&
               filmSubscriptions.Any(fs => userSubscriptions.Contains(fs));
    }

    public async Task AddSubscriptionAsync(Subscription subscription)
    {
        await _dbContext.Subscriptions.AddAsync(subscription);
        await _dbContext.SaveChangesAsync();
    }

    public async Task PurchaseSubscriptionAsync(SubscriptionDto dto)
    {
        var user = await _dbContext.Users
            .Include(u => u.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == dto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == dto.SubscriptionId);

        if (subscription == null)
            throw new NotFoundException("Не удалось найти подписку");

        if (user.Subscriptions.Any(x => x.Id == subscription.Id))
            throw new IncorrectOperationException("Неудалось приобрести данную подписку, так как она уже приобретена");
        
        user.Subscriptions.Add(subscription);

        await _dbContext.SaveChangesAsync();
        
        var userSubscription = _dbContext.UserSubscriptions.FirstOrDefault(x => x.UserId == user.Id && x.SubscriptionId == subscription.Id)!;

        userSubscription.Expires =
            subscription.PeriodInDays == null
                ? null
                : DateTime.Now.AddDays(subscription.PeriodInDays.Value);

        await _dbContext.SaveChangesAsync();
    }

    public async Task ExtendSubscriptionAsync(SubscriptionDto dto)
    {
        var user = await _dbContext.Users
            .Include(u => u.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == dto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        var subscription = user.Subscriptions.FirstOrDefault(x => x.Id == dto.SubscriptionId);
        
        if (subscription == null)
            throw new NotFoundException("Не удалось найти подписку");

        if (subscription.PeriodInDays == null)
            throw new IncorrectOperationException("Нельзя продлевать бессрочные подписки");
        
        var userSubscription = _dbContext.UserSubscriptions.FirstOrDefault(x => x.SubscriptionId == dto.SubscriptionId)!;
        
        userSubscription.Expires += TimeSpan.FromDays(subscription.PeriodInDays.Value);

        await _dbContext.SaveChangesAsync();
    }
}