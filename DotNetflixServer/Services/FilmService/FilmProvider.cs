using System.Collections;
using DataAccess;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;
using Microsoft.EntityFrameworkCore;
using Services.Mappers;

namespace Services.FilmService;

public class FilmProvider : IFilmProvider
{
    private readonly ApplicationDBContext _dbContext;

    public FilmProvider(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> GetFilmsCountAsync()
    {
        return await _dbContext.Movies.CountAsync();
    }

    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director)
    {
        if (type is not null)
        {
            _dbContext.Movies
                .Include(m => m.Type);

            return _dbContext.Movies
                .Where(m => m.Type.Name == type)
                .AsEnumerable()
                .Select(m => m.ToMovieForSearchPageDto());
        }

        IQueryable<MovieInfo>? result = null;

        if (name is not null)
        {
            result = _dbContext.Movies.Where(m => m.Name.Contains(name));
        }

        if (year is not null)
        {
            result = (result ?? _dbContext.Movies).Where(m => m.Year == year);
        }

        if (country is not null)
        {
            _dbContext.Movies
                .Include(m => m.Countries)
                .ThenInclude(cm => cm.Country);

            result = (result ?? _dbContext.Movies).Where(m => m.Countries.Any(cm => cm.Country.Name == country));
        }

        if (genres is not null && genres?.Length != 0)
        {
            _dbContext.Movies
                .Include(m => m.Genres)
                .ThenInclude(gm => gm.Genre);

            result = (result ?? _dbContext.Movies).Where(m => m.Genres.Count(gm => genres!.Contains(gm.Genre.Name)) == genres!.Length);
        }

        if (actors is not null && actors?.Length != 0 || director is not null)
        {
            _dbContext.Movies
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Person)
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Profession);

            if (actors is not null)
            {
                result = (result ?? _dbContext.Movies).Where(m => m.Proffessions
                        .Count(pm => pm.Profession.Name == "актеры" && actors!.Contains(pm.Person.Name)) == actors!.Length);
            }

            if (director is not null)
            {
                result = (result ?? _dbContext.Movies).Where(m => m.Proffessions
                        .Any(pm => pm.Profession.Name == "режиссеры" && pm.Person.Name == director));
            }
        }

        return result!
            .Select(m => m.ToMovieForSearchPageDto());
    }

    public IEnumerable GetAllFilms()
    {
        return _dbContext.Movies
            .Where(m => m.CategoryId != null)
            .Include(movie => movie.Category)
            .AsEnumerable()
            .Select(m => m.ToMovieForMainPageDto())
            .GroupBy(m => m.Category)
            .Select(g => new { Category = g.Key, Films = g });
    }

    public async Task<MovieForMoviePageDto?> GetFilmByIdAsync(int id)
    {
        var result = await _dbContext.Movies
            .Where(m => m.Id == id)
            .Include(movie => movie.Type)
            .Include(movie => movie.Category)
            .Include(movie => movie.Budget)
            .Include(movie => movie.Fees)
            .Include(movie => movie.Countries)
                .ThenInclude(cm => cm.Country)
            .Include(movie => movie.Genres)
                .ThenInclude(gm => gm.Genre)
            .Include(movie => movie.SeasonsInfo)
            .Include(movie => movie.Proffessions)
                .ThenInclude(pm => pm.Person)
            .Include(movie => movie.Proffessions)
                .ThenInclude(pm => pm.Profession)
            .Include(movie => movie.Fees.World)
            .Include(movie => movie.Fees.Russia)
            .Include(movie => movie.Fees.USA)
            .FirstOrDefaultAsync();

        return result?.ToMovieForMoviePageDto();
    }

    public async Task AddFilmAsync(MovieInfo movieInfo)
    {
        _dbContext.Movies.Add(movieInfo);
        await _dbContext.SaveChangesAsync();
    }

    public IEnumerable<string> GetAllNames(int page)
    {
        return _dbContext.Movies
            .Skip(15 * (page - 1))
            .Take(15)
            .Select(x => x.Name);
    }
}