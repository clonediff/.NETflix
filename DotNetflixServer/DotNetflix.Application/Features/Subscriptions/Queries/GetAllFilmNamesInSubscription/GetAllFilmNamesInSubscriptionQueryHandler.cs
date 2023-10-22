using DataAccess;
using Domain.Exceptions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;

public class GetAllFilmNamesInSubscriptionQueryHandler : IQueryHandler<GetAllFilmNamesInSubscriptionQuery, IEnumerable<string>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllFilmNamesInSubscriptionQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<string>> Handle(GetAllFilmNamesInSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions
            .Where(s => s.Id == request.SubscriptionId)
            .Include(s => s.Movies)
            .FirstOrDefaultAsync(s => s.Id == request.SubscriptionId, cancellationToken);
        
        if (subscription is null || !subscription.IsAvailable)
            throw new NotFoundException("Не удалось найти подписку");

        return subscription.Movies.Select(movie => movie.Name);
    }
}
