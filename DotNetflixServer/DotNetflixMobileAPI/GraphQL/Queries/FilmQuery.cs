using Contracts.Shared;
using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmById;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using HotChocolate.Authorization;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL.Queries;

[Authorize]
public class FilmQuery
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public FilmQuery(IServiceScopeFactory serviceScopeFactory)
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

    public async Task<MovieForGqlDto<MovieForMoviePageDto>> GetFilmById(HttpContext context, int filmId, string? userId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        
        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        
        var getUserIdQuery = new GetUserIdQuery(context.User);
        userId = await mediator.Send(getUserIdQuery);

        var query = new GetFilmByIdQuery(filmId, userId);
        var result = await mediator.Send(query);
        return result.Match(success: dto => new MovieForGqlDto<MovieForMoviePageDto>(dto, null), 
            failure: error => new MovieForGqlDto<MovieForMoviePageDto>(null, error));
    }
}