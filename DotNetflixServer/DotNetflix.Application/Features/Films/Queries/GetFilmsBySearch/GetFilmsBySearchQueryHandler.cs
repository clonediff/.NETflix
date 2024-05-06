using Domain.Entities;
using DotNetflix.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

internal class GetFilmsBySearchQueryHandler : IQueryHandler<GetFilmsBySearchQuery, IEnumerable<MovieForSearchPageDto>>
{
    private readonly DbContext _dbContext;

    public GetFilmsBySearchQueryHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<MovieForSearchPageDto>> Handle(GetFilmsBySearchQuery request,
        CancellationToken cancellationToken)
    {
        if (request.Dto.Type is not null)
        {
            return Task.FromResult(_dbContext.Set<MovieInfo>()
                .Include(m => m.Type)
                .Where(m => m.Type.Name == request.Dto.Type)
                .Select(m => m.ToMovieForSearchPageDto())
                .AsEnumerable()
            );
        }

        IQueryable<MovieInfo>? result = null;

        if (request.Dto.Name is not null)
        {
            result = _dbContext.Set<MovieInfo>().Where(m => m.Name.Contains(request.Dto.Name));
        }

        if (request.Dto.Year is not null)
        {
            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m => m.Year == request.Dto.Year);
        }

        if (request.Dto.Country is not null)
        {
            _dbContext.Set<MovieInfo>()
                .Include(m => m.Countries)
                    .ThenInclude(cm => cm.Country);

            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                m.Countries.Any(cm => cm.Country.Name == request.Dto.Country));
        }

        if (request.Dto.Genres is not null && request.Dto.Genres?.Length != 0)
        {
            _dbContext.Set<MovieInfo>().Include(m => m.Genres).ThenInclude(gm => gm.Genre);

            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                m.Genres.Count(gm => request.Dto.Genres!.Contains(gm.Genre.Name)) == request.Dto.Genres!.Length);
        }

        if (request.Dto.Actors is not null && request.Dto.Actors?.Length != 0 || request.Dto.Director is not null)
        {
            _dbContext.Set<MovieInfo>()
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Person)
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Profession);

            if (request.Dto.Actors is not null)
            {
                result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                    m.Proffessions.Count(pm =>
                        pm.Profession.Name == "актеры" && request.Dto.Actors!.Contains(pm.Person.Name)) ==
                    request.Dto.Actors!.Length);
            }

            if (request.Dto.Director is not null)
            {
                result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                    m.Proffessions.Any(pm => pm.Profession.Name == "режиссеры" && pm.Person.Name == request.Dto.Director));
            }
        }

        return Task.FromResult(result!.Select(m => m.ToMovieForSearchPageDto()).AsEnumerable());
    }
}
