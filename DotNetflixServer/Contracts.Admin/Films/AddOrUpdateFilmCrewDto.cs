namespace Contracts.Admin.Films;

public record AddOrUpdateFilmCrewDto(int Id, int ProfessionId, string? Name, string? Photo);
