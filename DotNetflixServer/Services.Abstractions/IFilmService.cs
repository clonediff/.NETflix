using Contracts.Movies;

namespace Services.Abstractions;

public interface IFilmService
{
    IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(MovieSearchDto dto);
    IDictionary<string, IEnumerable<MovieForMainPageDto>> GetAllFilms();
    Task<MovieForMoviePageDto> GetFilmByIdAsync(int filmId, string? userId);
}