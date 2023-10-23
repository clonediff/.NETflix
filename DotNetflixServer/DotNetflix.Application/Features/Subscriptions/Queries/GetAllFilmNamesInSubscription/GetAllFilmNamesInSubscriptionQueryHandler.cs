using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;

internal class GetAllFilmNamesInSubscriptionQueryHandler : IQueryHandler<GetAllFilmNamesInSubscriptionQuery, Result<IEnumerable<string>, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetAllFilmNamesInSubscriptionQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<IEnumerable<string>, string>> Handle(GetAllFilmNamesInSubscriptionQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _dbContext.Subscriptions
            .Where(s => s.Id == request.SubscriptionId)
            .Include(s => s.Movies)
            .FirstOrDefaultAsync(s => s.Id == request.SubscriptionId, cancellationToken);
        
        if (subscription is null || !subscription.IsAvailable)
            return "Не удалось найти подписку";

        return new Result<IEnumerable<string>, string>(subscription.Movies.Select(movie => movie.Name));
    }
}
