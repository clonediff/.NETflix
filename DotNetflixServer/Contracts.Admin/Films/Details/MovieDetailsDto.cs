namespace Contracts.Admin.Films.Details;

public record MovieDetailsDto(
    string Name,
    int Year,
    string? Description,
    string? ShortDescription,
    string? Slogan,
    double? Rating,
    int MovieLength,
    int? AgeRating,
    string? PosterUrl,
    string Type,
    string? Category,
    string? Budget,
    FeesDetailsDto? Fees,
    IEnumerable<string> Countries,
    IEnumerable<string> Genres,
    IEnumerable<SeasonDetailsDto>? Seasons,
    IEnumerable<string> SubscriptionNames,
    IEnumerable<PersonDetailsDto> FilmCrew);