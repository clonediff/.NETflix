using System.Collections;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;

namespace Services.FilmService;

public interface IFilmService
{
    Task<int> GetFilmsCountAsync();
    IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director);
    IEnumerable GetAllFilms();
    Task<MovieForMoviePageDto> GetFilmByIdAsync(int filmId, string? userId);
    Task AddFilmAsync(MovieInfo movieInfo);
    Task<PaginationDataDto<string>> GetFilmsFilteredAsync(int page, string? name);
}