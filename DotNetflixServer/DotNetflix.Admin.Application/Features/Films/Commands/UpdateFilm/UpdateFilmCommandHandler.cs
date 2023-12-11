using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;
using Services.Shared.MovieMetaDataService;

namespace DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;

internal class UpdateFilmCommandHandler : ICommandHandler<UpdateFilmCommand, IEnumerable<Guid>>
{
    private readonly DbContext _dbContext;
    private readonly IMovieMetaDataService _movieMetaDataService;

    public UpdateFilmCommandHandler(DbContext dbContext, IMovieMetaDataService movieMetaDataService)
    {
        _dbContext = dbContext;
        _movieMetaDataService = movieMetaDataService;
    }

    public async Task<IEnumerable<Guid>> Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();

        _dbContext.Set<CountryMovieInfo>().RemoveRange(
            _dbContext.Set<CountryMovieInfo>().Where(cmi => cmi.MovieInfoId == request.Id));
        
        _dbContext.Set<CountryMovieInfo>().AddRange(
            _dbContext.Set<Country>()
                .Where(c => request.Countries.Contains(c.Id))
                .Select(c => new CountryMovieInfo
                {
                    CountryId = c.Id,
                    MovieInfoId = request.Id
                }));

        _dbContext.Set<GenreMovieInfo>().RemoveRange(
            _dbContext.Set<GenreMovieInfo>().Where(gmi => gmi.MovieInfoId == request.Id));
        
        _dbContext.Set<GenreMovieInfo>().AddRange(
            _dbContext.Set<Genre>()
                .Where(g => request.Genres.Contains(g.Id))
                .Select(g => new GenreMovieInfo
                {
                    GenreId = g.Id,
                    MovieInfoId = request.Id
                }));

        if (request.SeasonsToDelete.Count != 0)
        {
            _dbContext.Set<SeasonsInfo>().RemoveRange(
                _dbContext.Set<SeasonsInfo>().Where(si => request.SeasonsToDelete.Contains(si.Id)));
        }

        if (request.PeopleToDelete.Count != 0)
        {
            _dbContext.Set<PersonProffessionInMovie>().RemoveRange(
                request.PeopleToDelete.Select(ptd => new PersonProffessionInMovie
                {
                    PersonId = ptd.PersonId,
                    ProfessionId = ptd.ProfessionId,
                    MovieInfoId = request.Id
                }));
        }

        _dbContext.Set<MovieInfo>().Update(movie);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        if (movie.Fees is null && request.Fees.Id != 0)
        {
            var fees = await _dbContext.Set<Fees>().FirstOrDefaultAsync(f => f.Id == request.Fees.Id, cancellationToken);

            _dbContext.Entry(fees!).State = EntityState.Deleted;

            if (fees!.WorldId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.WorldId.Value }).State = EntityState.Deleted;
            if (fees!.RussiaId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.RussiaId.Value }).State = EntityState.Deleted;
            if (fees!.USAId is not null)
                _dbContext.Entry(new CurrencyValue { Id = fees!.USAId.Value }).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        if (movie.Budget is null && request.Budget.Id != 0)
        {
            _dbContext.Entry(new CurrencyValue { Id = request.Budget.Id }).State = EntityState.Deleted;
            
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        foreach (var trailerMetaData in request.TrailersMetaData.Where(x => x.Id is not null))
        {
            await _movieMetaDataService.UpdateMetaDataAsync(request.Id, trailerMetaData.Id!.Value, "trailers", trailerMetaData);
        }

        foreach (var posterMetaData in request.PostersMetaData.Where(x => x.Id is not null))
        {
            await _movieMetaDataService.UpdateMetaDataAsync(request.Id, posterMetaData.Id!.Value, "posters", posterMetaData);
        }

        var trailerIds = Enumerable.Empty<Guid>();
        var posterIds = Enumerable.Empty<Guid>();

        if (request.TrailersMetaData.Any(x => x.Id is null))
        {
            trailerIds = await _movieMetaDataService.AddMetaDataAsync(request.Id, "trailers", request.TrailersMetaData);
        }

        if (request.PostersMetaData.Any(x => x.Id is null))
        {
            posterIds = await _movieMetaDataService.AddMetaDataAsync(request.Id, "posters", request.PostersMetaData);
        }

        foreach (var guid in request.MetaDataToDelete)
        {
            await _movieMetaDataService.DeleteMetaDataAsync(guid);
        }

        return trailerIds.Concat(posterIds);
    }
}