using DataAccess;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;
using Services.Mappers;
using Services.PaymentService;

namespace Services.SubscriptionService;

public class SubscriptionService : ISubscriptionService
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IPaymentService _paymentService;

    public SubscriptionService(ApplicationDBContext dbContext, IPaymentService paymentService)
    {
        _dbContext = dbContext;
        _paymentService = paymentService;
    }

    public async Task<int> GetSubscriptionsCountAsync()
    {
        return await _dbContext.Subscriptions.CountAsync();
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

    public IEnumerable<FilmInSubscriptionDto> GetAllFilms(int subscriptionId, string? name)
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
        _dbContext.Subscriptions.Update(new Subscription
        {
            Id = dto.Id,
            Cost = dto.Cost,
            Name = dto.Name,
            PeriodInDays = dto.PeriodInDays
        });

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

    public async Task<IEnumerable<GetUserSubscriptionDto>> GetAllUserSubscriptionsAsync(string userId)
    {
        var user = await _dbContext.Users
            .Include(u => u.UserSubscriptions)
                .ThenInclude(us => us.Subscription)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        return user.UserSubscriptions
            .Select(us => new GetUserSubscriptionDto
            {
                Id = us.Subscription.Id,
                SubscriptionName = us.Subscription.Name,
                Expires = us.Expires,
                Cost = us.Subscription.Cost
            });
    }

    public async IAsyncEnumerable<string> GetAllFilmNames(int subscriptionId)
    {
        var subscription = await _dbContext.Subscriptions
            .Where(s => s.Id == subscriptionId)
            .Include(s => s.Movies)
            .FirstOrDefaultAsync(s => s.Id == subscriptionId);
        
        if (subscription == null || !subscription.IsAvailable)
            throw new NotFoundException("Не удалось найти подписку");

        foreach (var movie in subscription.Movies)
        {
            yield return movie.Name;
        }
    }

    public IEnumerable<AvailableSubscriptionDto> GetAllSubscriptions(string userId)
    {
        var userSubscriptionIds = _dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Subscriptions)
            .SelectMany(u => u.Subscriptions.Select(s => s.Id));
        
        if (userSubscriptionIds == null)
            throw new NotFoundException("Не удалось найти пользователя");
        
        return _dbContext.Subscriptions
            .Where(s => s.IsAvailable)
            .Include(s => s.Movies)
            .Select(s => new AvailableSubscriptionDto
            {
                PeriodInDays = s.PeriodInDays,
                Cost = s.Cost,
                Name = s.Name,
                Id = s.Id,
                FilmNames = s.Movies.Select(m => m.Name),
                BelongsToUser = userSubscriptionIds.Contains(s.Id)
            })
            .AsEnumerable();
    }

    public async Task PurchaseSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto)
    {
        var user = await _dbContext.Users
            .Include(u => u.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == userSubscriptionDto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        var subscription = await _dbContext.Subscriptions.FirstOrDefaultAsync(x => x.Id == userSubscriptionDto.SubscriptionId);

        if (subscription == null || !subscription.IsAvailable)
            throw new NotFoundException("Не удалось найти подписку");

        if (user.Subscriptions.Any(x => x.Id == subscription.Id))
            throw new IncorrectOperationException("Неудалось приобрести данную подписку, так как она уже приобретена");
        
        if (!_paymentService.PayByCard(cardDataDto, subscription.Cost))
            throw new IncorrectOperationException("Не удалось приобрести данную подписку, так как введены некорректные реквизиты к оплате");
        
        user.Subscriptions.Add(subscription);

        await _dbContext.SaveChangesAsync();
        
        var userSubscription = _dbContext.UserSubscriptions.FirstOrDefault(x => x.UserId == user.Id && x.SubscriptionId == subscription.Id)!;

        userSubscription.Expires =
            subscription.PeriodInDays == null
                ? null
                : DateTime.Now.AddDays(subscription.PeriodInDays.Value);

        await _dbContext.SaveChangesAsync();
    }

    public async Task ExtendSubscriptionAsync(UserSubscriptionDto userSubscriptionDto, CardDataDto cardDataDto)
    {
        var user = await _dbContext.Users
            .Include(u => u.Subscriptions)
            .FirstOrDefaultAsync(x => x.Id == userSubscriptionDto.UserId);

        if (user == null)
            throw new NotFoundException("Не удалось найти пользователя");

        var subscription = user.Subscriptions.FirstOrDefault(x => x.Id == userSubscriptionDto.SubscriptionId);
        
        if (subscription == null)
            throw new NotFoundException("Не удалось найти подписку");

        if (subscription.PeriodInDays == null)
            throw new IncorrectOperationException("Нельзя продлевать бессрочные подписки");
        
        if (!_paymentService.PayByCard(cardDataDto, subscription.Cost))
            throw new IncorrectOperationException("Не удалось продлить данную подписку, так как введены некорректные реквизиты к оплате");
        
        var userSubscription = _dbContext.UserSubscriptions.FirstOrDefault(x => x.SubscriptionId == userSubscriptionDto.SubscriptionId)!;
        
        userSubscription.Expires += TimeSpan.FromDays(subscription.PeriodInDays.Value);

        await _dbContext.SaveChangesAsync();
    }
}