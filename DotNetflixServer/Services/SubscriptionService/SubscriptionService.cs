using DataAccess;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;
using Services.Mappers;

namespace Services.SubscriptionService;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationDBContext _dbContext;

    public SubscriptionService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetSubscriptionsCountAsync()
    {
        return await _dbContext.Subscriptions.CountAsync();
    }

    public async Task<List<string>> GetAllUserSubscriptionsAsync(string userId)
    {
        var user = await _dbContext.Users
            .Include(x => x.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == userId);

        return user!.Subscriptions
            .Select(s => s.Name)
            .ToList();
    }

    public async Task<PaginationDataDto<SubscriptionDto>> GetSubscriptionsFilteredAsync(string? name, int page)
    {
        var filteredSubscriptions = _dbContext.Subscriptions
            .Where(x => name == null || x.Name.Contains(name))
            .Include(s => s.Users);
        
        var filteredSubscriptionsCount = await filteredSubscriptions.CountAsync();
        
        var subscriptions = await filteredSubscriptions
            .Skip(25 * (page - 1))
            .Take(25)
            .ToListAsync();

        return new PaginationDataDto<SubscriptionDto>
        {
            Data = subscriptions.Select(x => x.ToSubscriptionDto()),
            Count = filteredSubscriptionsCount
        };
    }

    public IEnumerable<FilmInSubscriptionDto> GetAllFilmsWithSubscriptionAsync(int subscriptionId, string? name)
    {
        return _dbContext.Movies
            .Where(x => name == null || x.Name.Contains(name))
            .Include(m => m.Subscriptions)
            .Select(m => new FilmInSubscriptionDto
            {
                Id = m.Id,
                Name = m.Name,
                IsInSubscription = m.Subscriptions.Any(s => s.Id == subscriptionId)
            })
            .OrderByDescending(x => x.IsInSubscription);
    }

    public async Task UpdateFilmsInSubscriptionAsync(int subscriptionId, IDictionary<int, bool> movies)
    {
        var subscription = await _dbContext.Subscriptions
            .Include(s => s.SubscriptionMovies)
            .FirstOrDefaultAsync(x => x.Id == subscriptionId);
        
        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        subscription.SubscriptionMovies.RemoveAll(x => movies.ContainsKey(x.MovieInfoId) && !movies[x.MovieInfoId]);
        subscription.SubscriptionMovies.AddRange(movies
            .Where(x => x.Value)
            .Select(pair => new SubscriptionMovieInfo()
            {
                MovieInfoId = pair.Key,
                SubscriptionId = subscriptionId
            }));

        await _dbContext.SaveChangesAsync();
    }

    public bool HaveCommonSubscriptions(List<string> userSubscriptions, List<string> filmSubscriptions)
    {
        return filmSubscriptions.Count == 0 ||
               userSubscriptions.Count != 0 &&
               filmSubscriptions.Any(fs => userSubscriptions.Contains(fs));
    }

    public async Task AddSubscriptionAsync(AddSubscriptionDto dto)
    {
        var subscription = new Subscription
        {
            Name = dto.Name,
            PeriodInDays = dto.PeriodInDays,
            Cost = dto.Cost,
            IsAvailable = false
        };

        await _dbContext.Subscriptions.AddAsync(subscription);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateSubscriptionAsync(UpdateSubscriptionDto dto)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        subscription.Name = dto.Name;
        subscription.PeriodInDays = dto.PeriodInDays;
        subscription.Cost = dto.Cost;

        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteSubscription(int subscriptionId)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == subscriptionId);

        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        _dbContext.Subscriptions.Remove(subscription);

        await _dbContext.SaveChangesAsync();
    }

    public async Task ChangeSubscriptionAvailabilityAsync(SubscriptionAvailabilityDto dto)
    {
        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        subscription.IsAvailable = dto.IsAvailable;

        await _dbContext.SaveChangesAsync();
    }

    public async Task PurchaseSubscriptionAsync(UserSubscriptionDto dto)
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

    public async Task ExtendSubscriptionAsync(UserSubscriptionDto dto)
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