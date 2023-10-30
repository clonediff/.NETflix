using DataAccess;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;

internal class GetFilmByIdQueryHandler : IQueryHandler<GetFilmByIdQuery, Result<GetFilmByIdDto, string>>
{
    private readonly ApplicationDBContext _dbContext;

    public GetFilmByIdQueryHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<GetFilmByIdDto, string>> Handle(GetFilmByIdQuery request, CancellationToken cancellationToken)
    {
        var film = await _dbContext.Movies
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .Include(m => m.Genres)
                .ThenInclude(g => g.Genre)
            .Include(m => m.Type)
            .Include(m => m.Category)
            .Include(m => m.Budget)
            .Include(m => m.Countries)
                .ThenInclude(c => c.Country)
            .Include(m => m.Fees)
            .Include(m => m.Fees.World)
            .Include(m => m.Fees.Russia)
            .Include(m => m.Fees.USA)
            .Include(m => m.SeasonsInfo)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Person)
            .Include(m => m.Proffessions)
                .ThenInclude(p => p.Profession)
            .FirstOrDefaultAsync(cancellationToken);

        if (film is null)
            return "Не удалось найти фильм";

        return film.ToGetFilmByIdDto();
    }
}