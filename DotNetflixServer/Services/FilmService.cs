using Contracts.Movies;
using DataAccess;
using Domain.Entities;
using Domain.Exceptions;
using Mappers;
using Microsoft.EntityFrameworkCore;
using Services.Abstractions;

namespace Services;

public class FilmService : IFilmService
{
    private readonly ApplicationDBContext _dbContext;

    public FilmService(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<MovieForSearchPageDto> GetFilmsBySearch(MovieSearchDto dto)
    {
        if (dto.Type is not null)
        {
            _dbContext.Movies
                .Include(m => m.Type);

            return _dbContext.Movies
                .Where(m => m.Type.Name == dto.Type)
                .AsEnumerable()
                .Select(m => m.ToMovieForSearchPageDto());
        }

        IQueryable<MovieInfo>? result = null;

        if (dto.Name is not null)
        {
            result = _dbContext.Movies.Where(m => m.Name.Contains(dto.Name));
        }

        if (dto.Year is not null)
        {
            result = (result ?? _dbContext.Movies).Where(m => m.Year == dto.Year);
        }

        if (dto.Country is not null)
        {
            _dbContext.Movies
                .Include(m => m.Countries)
                .ThenInclude(cm => cm.Country);

            result = (result ?? _dbContext.Movies).Where(m => m.Countries.Any(cm => cm.Country.Name == dto.Country));
        }

        if (dto.Genres is not null && dto.Genres?.Length != 0)
        {
            _dbContext.Movies
                .Include(m => m.Genres)
                .ThenInclude(gm => gm.Genre);

            result = (result ?? _dbContext.Movies).Where(m => m.Genres.Count(gm => dto.Genres!.Contains(gm.Genre.Name)) == dto.Genres!.Length);
        }

        if (dto.Actors is not null && dto.Actors?.Length != 0 || dto.Director is not null)
        {
            _dbContext.Movies
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Person)
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Profession);

            if (dto.Actors is not null)
            {
                result = (result ?? _dbContext.Movies).Where(m => m.Proffessions
                        .Count(pm => pm.Profession.Name == "актеры" && dto.Actors!.Contains(pm.Person.Name)) == dto.Actors!.Length);
            }

            if (dto.Director is not null)
            {
                result = (result ?? _dbContext.Movies).Where(m => m.Proffessions
                        .Any(pm => pm.Profession.Name == "режиссеры" && pm.Person.Name == dto.Director));
            }
        }

        return result!
            .Select(m => m.ToMovieForSearchPageDto());
    }

    public IDictionary<string, IEnumerable<MovieForMainPageDto>> GetAllFilms()
    {
        return _dbContext.Movies
            .Where(m => m.CategoryId != null)
            .Include(movie => movie.Category)
            .AsEnumerable()
            .Select(m => m.ToMovieForMainPageDto())
            .GroupBy(m => m.Category)
            .ToDictionary(g => g.Key, g => g.AsEnumerable());
    }

    public async Task<MovieForMoviePageDto> GetFilmByIdAsync(int filmId, string? userId)
    {
        var availableMovies = await GetAvailableFilmIdsAsync(userId);
        
        if (_dbContext.SubscriptionMovies.Any(sm => sm.MovieInfoId == filmId) && !availableMovies.Contains(filmId))
        {
            throw new IncorrectOperationException("Оформите подписку, чтобы получить доступ к данному контенту");
        }

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
            .FirstOrDefaultAsync();

        if (movie is null)
            throw new NotFoundException("Не удалось найти запрашиваемый контент");

        return movie.ToMovieForMoviePageDto();
    }

    // TODO: исправить в NETFLIX-73
    private async Task<IEnumerable<int>> GetAvailableFilmIdsAsync(string? userId)
    {
        if (userId is null)
            return Enumerable.Empty<int>();
        
        var user = await _dbContext.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Subscriptions)
            .ThenInclude(s => s.Movies)
            .FirstOrDefaultAsync(u => u.Id == userId);
        
        return user!.Subscriptions.SelectMany(s => s.Movies.Select(m => m.Id));
    }
}