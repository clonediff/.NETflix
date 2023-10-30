using DataAccess;
using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Commands.UpdateFilm;

internal class UpdateFilmCommandHandler : ICommandHandler<UpdateFilmCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public UpdateFilmCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();

        _dbContext.CountryMovieInfo.RemoveRange(
            _dbContext.CountryMovieInfo.Where(cmi => cmi.MovieInfoId == request.Id));
        
        _dbContext.CountryMovieInfo.AddRange(
            _dbContext.Countries
                .Where(c => request.Countries.Contains(c.Id))
                .Select(c => new CountryMovieInfo
                {
                    CountryId = c.Id,
                    MovieInfoId = request.Id
                }));

        _dbContext.GenreMovieInfo.RemoveRange(
            _dbContext.GenreMovieInfo.Where(gmi => gmi.MovieInfoId == request.Id));
        
        _dbContext.GenreMovieInfo.AddRange(
            _dbContext.Genres
                .Where(g => request.Genres.Contains(g.Id))
                .Select(g => new GenreMovieInfo
                {
                    GenreId = g.Id,
                    MovieInfoId = request.Id
                }));

        if (request.SeasonsToDelete.Count != 0)
        {
            _dbContext.SeasonsInfos.RemoveRange(
                _dbContext.SeasonsInfos.Where(si => request.SeasonsToDelete.Contains(si.Id)));
        }

        if (request.PeopleToDelete.Count != 0)
        {
            _dbContext.PersonProffessionInMovie.RemoveRange(
                request.PeopleToDelete.Select(ptd => new PersonProffessionInMovie
                {
                    PersonId = ptd.PersonId,
                    ProfessionId = ptd.ProfessionId,
                    MovieInfoId = request.Id
                }));
        }

        _dbContext.Movies.Update(movie);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        if (movie.Fees is null && request.Fees.Id != 0)
        {
            var fees = await _dbContext.Fees.FirstOrDefaultAsync(f => f.Id == request.Fees.Id, cancellationToken);

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
    }
}