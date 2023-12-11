using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;
using Services.Shared.MovieMetaDataService;

namespace DotNetflix.Admin.Application.Features.Films.Commands.DeleteFilm;

internal class DeleteFilmCommandHandler : ICommandHandler<DeleteFilmCommand>
{
    private readonly DbContext _dbContext;
    private readonly IMovieMetaDataService _movieMetaDataService;

    public DeleteFilmCommandHandler(DbContext dbContext, IMovieMetaDataService movieMetaDataService)
    {
        _dbContext = dbContext;
        _movieMetaDataService = movieMetaDataService;
    }

    public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
    {
        var filmToDelete = new MovieInfo
        {
            Id = request.Id
        };

        _dbContext.Entry(filmToDelete).State = EntityState.Deleted;

        await _dbContext.SaveChangesAsync(cancellationToken);

        await _movieMetaDataService.DeleteMovieMetaDataAsync(request.Id);
    }
}