namespace DotNetflix.Analytics.Repositories;

public interface IFilmVisitsRepository
{
    Task CreateTableAsync();

    Task AddOrUpdateVisitAsync(int filmId);

    Task<int> GetFilmVisitsAsync(int filmId);
}