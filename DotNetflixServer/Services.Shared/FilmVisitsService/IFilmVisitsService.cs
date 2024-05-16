namespace Services.Shared.FilmVisitsService;

public interface IFilmVisitsService
{
    Task<string> HandleFilmVisitAsync(int filmId, bool declareQueue);
}