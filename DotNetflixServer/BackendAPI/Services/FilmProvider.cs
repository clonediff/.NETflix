using DBModels.BusinessLogic;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Services;

public class FilmProvider : IFilmProvider
{
    private readonly ApplicationDBContext _dbContext;
    
    public FilmProvider(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<MovieInfo> GetFilmsBySearch(string? type, string? name, int? year, string? country, string[]? genres, string[]? actors, string? director)
    {
        if (type is not null)
        {
            _dbContext.Movies
                .Include(m => m.Type);
            
            return _dbContext.Movies.Where(m => m.Type.Name == type);
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

        if (genres?.Length != 0)
        {
            _dbContext.Movies
                .Include(m => m.Genres)
                .ThenInclude(gm => gm.Genre);

            result = result is null
                ? _dbContext.Movies.Where(m => m.Genres.Count(gm => genres!.Contains(gm.Genre.Name)) == genres!.Length)
                : result.Where(m => m.Genres.Count(gm => genres!.Contains(gm.Genre.Name)) == genres!.Length);
        }

        if (actors?.Length != 0 || director is not null)
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

        return result!;
    }
}