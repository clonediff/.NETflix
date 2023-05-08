using System.Collections;
using DataAccess;
using DataAccess.Entities.BusinessLogic;
using DtoLibrary;
using DtoLibrary.MoviePage;
using Microsoft.EntityFrameworkCore;
using Services.Exceptions;
using Services.Mappers;
using Services.UserService;

namespace Services.FilmService;

public class FilmService : IFilmService
{
    private readonly ApplicationDBContext _dbContext;
    private readonly IUserService _userService;

    public FilmService(ApplicationDBContext dbContext, IUserService userService)
    {
        _dbContext = dbContext;
        _userService = userService;
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

    public async Task<MovieForMoviePageDto> GetFilmByIdAsync(int filmId, string? userId)
    {
        var movie = await _dbContext.Movies
            .Where(m => m.Id == filmId)
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
            .Include(movie => movie.Subscriptions)
            .FirstOrDefaultAsync();

        if (movie is null)
            throw new NotFoundException("Не удалось найти запрашиваемый контент");

        var availableMovies = await _userService.GetAvailableFilmIdsAsync(userId);

        if (movie.Subscriptions.Count == 0 || availableMovies.Contains(filmId))
        {
            return movie.ToMovieForMoviePageDto();
        }

        throw new IncorrectOperationException("Оформите подписку, чтобы получить доступ к данному контенту");
    }

    public async Task AddFilmAsync(MovieInfo movieInfo)
    {
        _dbContext.Movies.Add(movieInfo);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<PaginationDataDto<string>> GetFilmsFilteredAsync(int page, string? name)
    {
        var filteredMovies = _dbContext.Movies
            .Where(x => name == null || x.Name.Contains(name));

        var filteredMoviesCount = await filteredMovies.CountAsync();
        
        var movieNames = filteredMovies 
            .Skip(25 * (page - 1))
            .Take(25)
            .Select(x => x.Name);

        return new PaginationDataDto<string>
        {
            Data = movieNames,
            Count = filteredMoviesCount
        };
    }
}