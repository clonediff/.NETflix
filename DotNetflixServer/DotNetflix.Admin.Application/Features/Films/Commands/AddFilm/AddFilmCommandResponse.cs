namespace DotNetflix.Admin.Application.Features.Films.Commands.AddFilm;

public record AddFilmCommandResponse(int MovieId, IEnumerable<Guid> TrailerIds, IEnumerable<Guid> PosterIds);