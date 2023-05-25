namespace Contracts.Admin.Films;

public record UpdateFilmDto(
    int Id,
    string Name,
    int Year,
    string? Description,
    string? ShortDescription,
    string? Slogan,
    int MovieLength,
    int? AgeRating,
    double? Rating,
    string? PosterUrl,
    int Type,
    int? Category,
    CurrencyValueDto Budget,
    FeesDto Fees,
    IEnumerable<int> Countries,
    IEnumerable<int> Genres,
    IEnumerable<SeasonDto>? Seasons,
    List<int> SeasonsToDelete,
    IEnumerable<AddOrUpdateFilmCrewDto> PeopleToAdd,
    List<DeletePersonFromFilmDto> PeopleToDelete);
