using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.Admin.Application.Features.Films.Services;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

internal class AddFilmCommandHandler : ICommandHandler<AddFilmCommand, AddFilmCommandResponse>
{
    private readonly DbContext _dbContext;
    private readonly IMovieMetaDataService _movieMetaDataService;

    public AddFilmCommandHandler(DbContext dbContext, IMovieMetaDataService movieMetaDataService)
    {
        _dbContext = dbContext;
        _movieMetaDataService = movieMetaDataService;
    }

    public async Task<AddFilmCommandResponse> Handle(AddFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();
        
        _dbContext.Set<MovieInfo>().Add(movie);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        var trailerIds = Enumerable.Empty<Guid>();
        var posterIds = Enumerable.Empty<Guid>();

        if (request.TrailersMetaData.Any())
        {
            trailerIds = await _movieMetaDataService.AddMetaDataAsync(movie.Id, "trailers", request.TrailersMetaData);
        }

        if (request.PostersMetaData.Any())
        {
            posterIds = await _movieMetaDataService.AddMetaDataAsync(movie.Id, "posters", request.PostersMetaData);
        }

        return new AddFilmCommandResponse(movie.Id, trailerIds, posterIds);
    }
}