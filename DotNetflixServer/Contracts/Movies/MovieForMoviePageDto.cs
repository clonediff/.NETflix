using System.Collections;

namespace Contracts.Movies;

public class MovieForMoviePageDto
{
    public int Id { get; init; }
    public string Name { get; init; } = null!; // maxLength = 50
    public int Year { get; init; }
    public string? Description { get; init; }
    public string? ShortDescription { get; init; }
    public string? Slogan { get; init; }
    public double? Rating { get; init; }
    public int MovieLength { get; init; }
    public int? AgeRating { get; init; }
    public string? PosterUrl { get; init; }
    public string Type { get; init; } = null!;
    public string? Category { get; init; }
    public string? Budget { get; init; }
    public FeesDto? Fees { get; init; }
    public List<CountryDto> Countries { get; init; } = null!;
    public List<string> Genres { get; init; } = null!;
    public List<SeasonDto> SeasonsInfo { get; init; } = null!;
    public IDictionary<string, IEnumerable<PersonDto>> Professions { get; init; } = null!;
}