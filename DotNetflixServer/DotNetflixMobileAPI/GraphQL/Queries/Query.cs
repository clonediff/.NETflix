using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;
using DotNetflix.Application.Features.Users.Queries.GetUser;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflix.Application.Shared;
using HotChocolate.Authorization;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL.Queries;

public class Query
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Query(IServiceScopeFactory serviceScopeFactory)
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