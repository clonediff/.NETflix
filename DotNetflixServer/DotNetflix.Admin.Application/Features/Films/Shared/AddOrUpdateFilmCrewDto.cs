namespace DotNetflix.Admin.Application.Features.Films.Shared;

public record AddOrUpdateFilmCrewDto(int Id, int ProfessionId, string? Name, string? Photo);
