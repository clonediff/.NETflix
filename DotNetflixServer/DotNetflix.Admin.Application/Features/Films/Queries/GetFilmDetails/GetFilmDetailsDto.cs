namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmDetails;

public record GetFilmDetailsDto(
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
    GetFeesDetailsDto? Fees,
    IEnumerable<string> Countries,
    IEnumerable<string> Genres,
    IEnumerable<GetSeasonDetailsDto>? Seasons,
    IEnumerable<string> SubscriptionNames,
    IEnumerable<GetPersonDetailsDto> FilmCrew);