using System.Collections;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;

namespace Services.FilmService;

public interface IFilmProvider
{
    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director);
    public IEnumerable GetAllFilms();
    public Task<MovieForMoviePageDto?> GetFilmByIdAsync(int id);
    public Task AddFilmAsync(MovieInfo movieInfo);
}