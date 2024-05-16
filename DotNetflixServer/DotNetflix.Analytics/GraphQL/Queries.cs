using DotNetflix.Analytics.Repositories;

namespace DotNetflix.Analytics.GraphQL;

public class Queries
{
    private readonly IFilmVisitsRepository _filmVisitsRepository;

    public Queries(IFilmVisitsRepository filmVisitRepository)
    {
        _filmVisitsRepository = filmVisitRepository;
    }

    public Task<int> GetFilmVisits(int filmId)
    {
        return _filmVisitsRepository.GetFilmVisitsAsync(filmId);
    }
}