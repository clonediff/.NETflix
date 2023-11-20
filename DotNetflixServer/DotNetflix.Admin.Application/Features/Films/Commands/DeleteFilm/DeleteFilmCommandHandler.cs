using Domain.Entities;
using DotNetflix.CQRS.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Features.Films.Commands.DeleteFilm;

internal class DeleteFilmCommandHandler : ICommandHandler<DeleteFilmCommand>
{
    private readonly DbContext _dbContext;

    public DeleteFilmCommandHandler(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteFilmCommand request, CancellationToken cancellationToken)
    {
        var filmToDelete = new MovieInfo
        {
            Id = request.Id
        };

        _dbContext.Entry(filmToDelete).State = EntityState.Deleted;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}