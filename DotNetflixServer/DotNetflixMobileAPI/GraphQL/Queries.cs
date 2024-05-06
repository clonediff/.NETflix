using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL;

public class Queries
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Queries(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IDictionary<string, IEnumerable<MovieForMainPageDto>>> GetAllFilms()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetAllFilmsQuery();
        var result = await mediator.Send(query);
        return result;
    }

    public async Task<IEnumerable<MovieForSearchPageDto>> GetFilmsBySearch(MovieSearchDto dto)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetFilmsBySearchQuery(dto);
        var result = await mediator.Send(query);

        return result.ToList();
    }

    public async Task<IEnumerable<AvailableSubscriptionDto>> GetAllSubscriptions()
    {
        using var scope = _serviceScopeFactory.CreateScope();
        
        var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var userId = httpContext!.Request.Headers.Authorization.ToString();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var getAllSubscriptionsForUserQuery = new GetAllSubscriptionsForUserQuery(userId);
        var result = await mediator.Send(getAllSubscriptionsForUserQuery);

        return result.ToList();
    }
}