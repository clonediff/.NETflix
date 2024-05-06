using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;
using DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;
using DotNetflix.Application.Features.Users.Queries.GetUser;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflix.Application.Shared;
using DotNetflixMobileAPI.GraphQL.Models;
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

    public async Task<GraphQLResponse<MovieForMoviePageDto>> GetFilmById(int filmId, string? userId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var query = new GetFilmByIdQuery(filmId, userId);
        var result = await mediator.Send(query);

        return result;
    }

    public async Task<UserDto> GetUser()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;

        var query = new GetUserQuery(context.User);
        return await mediator.Send(query);
    }

    public async Task<IEnumerable<GetUserSubscriptionDto>?> GetAllUserSubscriptions()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;

        var getUserIdQuery = new GetUserIdQuery(context.User);
        var userId = await mediator.Send(getUserIdQuery);

        if (userId is null) return null;

        var getAllUserSubscriptionsQuery = new GetAllUserSubscriptionsQuery(userId);
        var subscriptions = await mediator.Send(getAllUserSubscriptionsQuery);
        return subscriptions.ToList();
    }
}