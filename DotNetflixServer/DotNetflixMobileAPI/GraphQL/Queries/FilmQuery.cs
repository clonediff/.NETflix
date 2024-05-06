using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
using DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL.Queries;

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
}