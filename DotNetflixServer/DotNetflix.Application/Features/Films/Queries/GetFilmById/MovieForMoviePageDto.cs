using Contracts.Shared;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmById;

public record MovieForMoviePageDto(
    int Id,
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
    FeesDto? Fees,
    IEnumerable<CountryDto> Countries,
    IEnumerable<string> Genres,
    IEnumerable<SeasonDto> SeasonsInfo,
    IEnumerable<TrailerMetaDataDto> TrailersMetaData,
    IEnumerable<PosterMetaDataDto> PostersMetaData,
    IDictionary<string, IEnumerable<PersonDto>> Professions);
