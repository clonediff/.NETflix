using DotNetflix.Admin.Application.Features.Films.Shared;
using DotNetflix.Admin.Application.Shared;

namespace DotNetflix.Admin.Application.Features.Films.Queries.GetFilmById;

public record GetFilmByIdDto(
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
    IEnumerable<GetFilmCrewDto> FilmCrew);
