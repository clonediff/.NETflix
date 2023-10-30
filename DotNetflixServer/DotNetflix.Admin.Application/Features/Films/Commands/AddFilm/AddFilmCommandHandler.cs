using DataAccess;
using DotNetflix.Admin.Application.Features.Films.Mapping;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

internal class AddFilmCommandHandler : ICommandHandler<AddFilmCommand>
{
    private readonly ApplicationDBContext _dbContext;

    public AddFilmCommandHandler(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(AddFilmCommand request, CancellationToken cancellationToken)
    {
        var movie = request.ToMovieInfo();
        
        _dbContext.Movies.Add(movie);
        
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}