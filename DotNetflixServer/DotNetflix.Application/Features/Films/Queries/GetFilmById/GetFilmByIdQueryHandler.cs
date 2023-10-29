using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.Films.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmById;

internal class GetFilmByIdQueryHandler : IQueryHandler<GetFilmByIdQuery, Result<MovieForMoviePageDto, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetFilmByIdQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<MovieForMoviePageDto, string>> Handle(GetFilmByIdQuery request,
        CancellationToken cancellationToken)
    {
        var availableMovies = await GetAvailableFilmIdsAsync(request.UserId);

        if (_dbContext.SubscriptionMovies.Any(sm => sm.MovieInfoId == request.FilmId) &&
            !availableMovies.Contains(request.FilmId))
            return "Оформите подписку, чтобы получить доступ к данному контенту";

        var movie = await _dbContext.Movies
            .Where(m => m.Id == request.FilmId)
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
            .FirstOrDefaultAsync(cancellationToken);

        if (movie is null)
            return "Не удалось найти запрашиваемый контент";

        return movie.ToMovieForMoviePageDto();
    }

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
