namespace Contracts.Admin.Films;

public record FilmCrewDto(int Id, string? Name, int ProfessionId, string ProfessionName);