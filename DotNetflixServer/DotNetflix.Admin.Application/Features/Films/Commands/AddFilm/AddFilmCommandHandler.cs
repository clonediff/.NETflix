using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.Admin.Application.Features.Films.Services;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

internal class AddFilmCommandHandler : ICommandHandler<AddFilmCommand, int>
{
    private readonly DbContext _dbContext;
    private readonly IMovieMetaDataService _movieMetaDataService;

    public AddFilmCommandHandler(DbContext dbContext, IMovieMetaDataService movieMetaDataService)
    {
        _dbContext = dbContext;
        _movieMetaDataService = movieMetaDataService;
    }

    public async Task<int> Handle(AddFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();
        
        _dbContext.Set<MovieInfo>().Add(movie);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        if (request.TrailersMetaData.Any())
        {
            await _movieMetaDataService.AddMetaDataAsync(movie.Id, "trailers", request.TrailersMetaData);
        }

        if (request.PostersMetaData.Any())
        {
            await _movieMetaDataService.AddMetaDataAsync(movie.Id, "posters", request.PostersMetaData);
        }

        return movie.Id;
    }
}