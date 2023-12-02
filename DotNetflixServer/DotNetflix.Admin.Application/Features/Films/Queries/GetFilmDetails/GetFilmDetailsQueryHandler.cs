using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.Admin.Application.Features.Films.Shared;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;

internal class GetFilmDetailsQueryHandler : IQueryHandler<GetFilmDetailsQuery, Result<GetFilmDetailsDto, string>>
{
    private readonly DbContext _dbContext;

    public GetFilmDetailsQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Result<GetFilmDetailsDto, string>> Handle(GetFilmDetailsQuery request, CancellationToken cancellationToken)
    {
        var film = await _dbContext.Set<MovieInfo>()
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

        var trailers = new List<TrailerMetaDataDto>
        {
            new TrailerMetaDataDto($"{request.Id}-{Guid.NewGuid()}", "test", DateTime.Now, "Русский", "720")
        };

        var posters = new List<PosterMetaDataDto>
        {
            new PosterMetaDataDto($"{request.Id}-{Guid.NewGuid()}", "test", "1920x1080")
        };

        return film.ToMovieDetailsDto(trailers, posters);
    }
}