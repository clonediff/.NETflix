using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Subscriptions;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Extensions;
using Mappers.Admin;
using Microsoft.EntityFrameworkCore;
using Services.Admin.Abstractions;

namespace Services.Admin;

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

    public async Task<PaginationDataDto<SubscriptionDto>> GetSubscriptionsFilteredAsync(string? name, int page)
    {
        var filteredSubscriptions = _dbContext.Subscriptions
            .Where(x => name == null || x.Name.Contains(name))
            .Include(s => s.Users);
        
        var filteredSubscriptionsCount = await filteredSubscriptions.CountAsync();
        
        var subscriptions = await filteredSubscriptions
            .Paginate(page, 25)
            .ToListAsync();

        return new PaginationDataDto<SubscriptionDto>(subscriptions.Select(x => x.ToSubscriptionDto()), filteredSubscriptionsCount);
    }

    public IEnumerable<FilmInSubscriptionDto> GetAllFilms(int subscriptionId, string? name)
    {
        return _dbContext.Movies
            .Where(x => name == null || x.Name.Contains(name))
            .Include(m => m.Subscriptions)
            .AsEnumerable()
            .Select(m => new FilmInSubscriptionDto(m.Id, m.Name, m.Subscriptions.Any(s => s.Id == subscriptionId)))
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
            .Select(pair => new SubscriptionMovieInfo
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
}