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

        if (_dbContext.UserSubscriptions.Any(us => us.SubscriptionId == subscriptionId))
            throw new IncorrectOperationException("Не удалось удалить подписку");

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

        userSubscription!.Expires += TimeSpan.FromDays(userSubscription.Subscription.PeriodInDays!.Value);

        await _dbContext.SaveChangesAsync();
    }
}