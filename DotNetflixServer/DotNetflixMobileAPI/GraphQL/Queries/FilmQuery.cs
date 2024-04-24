using DotNetflix.Application.Features.Films.Queries.GetAllFilms;
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
}