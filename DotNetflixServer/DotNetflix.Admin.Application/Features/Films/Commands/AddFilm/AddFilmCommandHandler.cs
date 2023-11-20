using Domain.Entities;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

internal class AddFilmCommandHandler : ICommandHandler<AddFilmCommand>
{
    private readonly DbContext _dbContext;

    public AddFilmCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();
        
        _dbContext.Set<MovieInfo>().Add(movie);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}