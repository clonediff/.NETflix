using Domain.Entities;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateFilmsInSubscription;

internal class UpdateFilmsInSubscriptionCommandHandler : ICommandHandler<UpdateFilmsInSubscriptionCommand, Result<int, string>>
{
    private readonly DbContext _dbContext;

    public UpdateFilmsInSubscriptionCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<int, string>> Handle(UpdateFilmsInSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Set<Subscription>()
            .Include(s => s.SubscriptionMovies)
            .FirstOrDefaultAsync(x => x.Id == request.SubscriptionId, cancellationToken);

        if (subscription is null)
            return "Не удалось найти подписку";

        subscription.SubscriptionMovies.RemoveAll(x => request.Movies.ContainsKey(x.MovieInfoId) && !request.Movies[x.MovieInfoId]);
        subscription.SubscriptionMovies.AddRange(request.Movies
            .Where(x => x.Value)
            .Select(pair => new SubscriptionMovieInfo
            {
                MovieInfoId = pair.Key,
                SubscriptionId = request.SubscriptionId
            }));

        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}