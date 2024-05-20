namespace Services.Shared.FilmVisitsService;

public interface IFilmVisitsService
{
    Task HandleFilmVisitAsync(int filmId);
}