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
        if (request.Type is not null)
        {
            _dbContext.Set<MovieInfo>().Include(m => m.Type);

            return Task.FromResult(_dbContext.Set<MovieInfo>().Where(m => m.Type.Name == request.Type).AsEnumerable()
                .Select(m => m.ToMovieForSearchPageDto()));
        }

        IQueryable<MovieInfo>? result = null;

        if (request.Name is not null)
        {
            result = _dbContext.Set<MovieInfo>().Where(m => m.Name.Contains(request.Name));
        }

        if (request.Year is not null)
        {
            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m => m.Year == request.Year);
        }

        if (request.Country is not null)
        {
            _dbContext.Set<MovieInfo>()
                .Include(m => m.Countries)
                    .ThenInclude(cm => cm.Country);

            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                m.Countries.Any(cm => cm.Country.Name == request.Country));
        }

        if (request.Genres is not null && request.Genres?.Length != 0)
        {
            _dbContext.Set<MovieInfo>().Include(m => m.Genres).ThenInclude(gm => gm.Genre);

            result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                m.Genres.Count(gm => request.Genres!.Contains(gm.Genre.Name)) == request.Genres!.Length);
        }

        if (request.Actors is not null && request.Actors?.Length != 0 || request.Director is not null)
        {
            _dbContext.Set<MovieInfo>()
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Person)
                .Include(m => m.Proffessions)
                    .ThenInclude(pm => pm.Profession);

            if (request.Actors is not null)
            {
                result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                    m.Proffessions.Count(pm =>
                        pm.Profession.Name == "актеры" && request.Actors!.Contains(pm.Person.Name)) ==
                    request.Actors!.Length);
            }

            if (request.Director is not null)
            {
                result = (result ?? _dbContext.Set<MovieInfo>()).Where(m =>
                    m.Proffessions.Any(pm => pm.Profession.Name == "режиссеры" && pm.Person.Name == request.Director));
            }
        }

        return Task.FromResult(result!.Select(m => m.ToMovieForSearchPageDto()).AsEnumerable());
    }
}
