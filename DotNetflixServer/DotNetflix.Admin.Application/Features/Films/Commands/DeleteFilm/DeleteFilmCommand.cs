using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Films.Commands.DeleteFilm;

public record DeleteFilmCommand(int Id) : ICommand;