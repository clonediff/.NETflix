namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;

public record GetFilmCrewDto(int Id, string? Name, int ProfessionId, string ProfessionName);