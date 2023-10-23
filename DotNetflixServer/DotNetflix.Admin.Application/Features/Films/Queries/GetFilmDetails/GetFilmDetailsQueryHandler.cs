using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;

internal class GetFilmDetailsQueryHandler : IQueryHandler<GetFilmDetailsQuery, Result<GetFilmDetailsDto, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetFilmDetailsQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<GetFilmDetailsDto, string>> Handle(GetFilmDetailsQuery request, CancellationToken cancellationToken)
    {
        var film = await _dbContext.Movies
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .Include(m => m.Type)
            .Include(m => m.Category)
            .Include(m => m.Budget)
            .Include(m => m.Fees)
            .Include(m => m.Fees.World)
            .Include(m => m.Fees.Russia)
            .Include(m => m.Fees.USA)
            .Include(m => m.SeasonsInfo)
            .Include(m => m.Subscriptions)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Profession)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Person)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Countries)
                .ThenInclude(c => c.Country)
            .FirstOrDefaultAsync(cancellationToken);

        if (film is null)
            return "Не удалось найти фильм";

        return film.ToMovieDetailsDto();
    }
}