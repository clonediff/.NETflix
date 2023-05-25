using Contracts.Admin.DataRepresentation;

namespace Contracts.Admin.Films;

public record MovieDto(
    string Name,
    int Year,
    string? Description,
    string? ShortDescription,
    string? Slogan,
    double? Rating,
    int MovieLength,
    int? AgeRating,
    string? PosterUrl,
    EnumDto<int> Type,
    EnumDto<int>? Category,
    CurrencyValueDto? Budget,
    FeesDto? Fees,
    IEnumerable<EnumDto<int>> Genres,
    IEnumerable<EnumDto<int>> Countries,
    IEnumerable<SeasonDto>? Seasons,
    IEnumerable<FilmCrewDto> FilmCrew);
