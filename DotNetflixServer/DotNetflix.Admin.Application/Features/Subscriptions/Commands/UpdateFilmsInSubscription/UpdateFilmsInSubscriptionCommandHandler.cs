using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateFilmsInSubscription;

internal class UpdateFilmsInSubscriptionCommandHandler : ICommandHandler<UpdateFilmsInSubscriptionCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public UpdateFilmsInSubscriptionCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateFilmsInSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions
            .Include(s => s.SubscriptionMovies)
            .FirstOrDefaultAsync(x => x.Id == request.SubscriptionId, cancellationToken);
        
        if (subscription is null)
            throw new NotFoundException("Не удалось найти подписку");

        subscription.SubscriptionMovies.RemoveAll(x => request.Movies.ContainsKey(x.MovieInfoId) && !request.Movies[x.MovieInfoId]);
        subscription.SubscriptionMovies.AddRange(request.Movies
            .Where(x => x.Value)
            .Select(pair => new SubscriptionMovieInfo
            {
                MovieInfoId = pair.Key,
                SubscriptionId = request.SubscriptionId
            }));

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}