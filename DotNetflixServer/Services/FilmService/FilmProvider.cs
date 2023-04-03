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
            result = result is null
                ? _dbContext.Movies.Where(m => m.Year == year)
                : result.Where(m => m.Year == year);
        }

        if (country is not null)
        {
            _dbContext.Movies
                .Include(m => m.Countries)
                .ThenInclude(cm => cm.Country);

            result = result is null
                ? _dbContext.Movies.Where(m => m.Countries.Any(cm => cm.Country.Name == country))
                : result.Where(m => m.Countries.Any(cm => cm.Country.Name == country));
        }

        if (genres is not null && genres?.Length != 0)
        {
            _dbContext.Movies
                .Include(m => m.Genres)
                .ThenInclude(gm => gm.Genre);

            result = result is null
                ? _dbContext.Movies.Where(m => m.Genres.Count(gm => genres!.Contains(gm.Genre.Name)) == genres!.Length)
                : result.Where(m => m.Genres.Count(gm => genres!.Contains(gm.Genre.Name)) == genres!.Length);
        }

        if (actors is not null && actors?.Length != 0 || director is not null)
        {
            _dbContext.Movies
                .Include(m => m.Proffessions)
                .ThenInclude(pm => pm.Person);

            if (actors?.Length != 0)
            {
                result = result is null
                    ? _dbContext.Movies.Where(m => m.Proffessions
                        .Count(pm => pm.Proffession == "актеры" && actors!.Contains(pm.Person.Name)) == actors!.Length)
                    : result.Where(m => m.Proffessions
                        .Count(pm => pm.Proffession == "актеры" && actors!.Contains(pm.Person.Name)) == actors!.Length);
            }

            if (director is not null)
            {
                result = result is null
                    ? _dbContext.Movies.Where(m => m.Proffessions
                        .Any(pm => pm.Proffession == "режиссеры" && pm.Person.Name == director))
                    : result.Where(m => m.Proffessions
                        .Any(pm => pm.Proffession == "режиссеры" && pm.Person.Name == director));
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
          .Include(movie => movie.Fees.World)
          .Include(movie => movie.Fees.Russia)
          .Include(movie => movie.Fees.USA)
          .FirstOrDefaultAsync();

        return result?.ToMovieForMoviePageDto();
    }

    public async Task AddFilmAsync(MovieInfo movieInfo)
    {
        var type = await _dbContext.Types.SingleAsync(x => x.Name == movieInfo.Type.Name);
        var category = movieInfo.Category != null ? await _dbContext.Categories.SingleAsync(x => x.Name == movieInfo.Category.Name) : null;

        var movieInfoCountryNames = movieInfo.Countries.Select(x => x.Country.Name);
        var countries = await _dbContext.Countries.Where(x => movieInfoCountryNames.Contains(x.Name)).ToDictionaryAsync(x => x.Name);

        var movieInfoGenreNames = movieInfo.Genres.Select(x => x.Genre.Name);
        var genres = await _dbContext.Genres.Where(x => movieInfoGenreNames.Contains(x.Name)).ToDictionaryAsync(x => x.Name);

        var movieInfoPeopleData = movieInfo.Proffessions.Select(x => x.Person.Photo);
        var people = await _dbContext.Persons.Where(x => movieInfoPeopleData.Contains(x.Photo)).ToDictionaryAsync(x => new { x.Name, x.Photo });

        movieInfo.Type = type;
        movieInfo.Category = category;

        foreach (var mm_movieCountry in movieInfo.Countries)
            mm_movieCountry.Country = countries[mm_movieCountry.Country.Name];

        foreach (var mm_movieGenre in movieInfo.Genres)
            mm_movieGenre.Genre = genres[mm_movieGenre.Genre.Name];

        foreach (var mm_moviePerson in movieInfo.Proffessions)
            if (people.ContainsKey(new { mm_moviePerson.Person.Name, mm_moviePerson.Person.Photo }))
                mm_moviePerson.Person = people[new { mm_moviePerson.Person.Name, mm_moviePerson.Person.Photo }];

        _dbContext.Movies.Add(movieInfo);
        await _dbContext.SaveChangesAsync();
    }
}