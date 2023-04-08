using DtoLibrary.MoviePage;

namespace AdminBackendAPI.Dto;

public class FilmInsertDto
{
    public string Name { get; set; }
    public int Year { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; }
    public string? Slogan { get; set; }
    public double? Rating { get; set; }
    public int MovieLength { get; set; }
    public int? AgeRating { get; set; }
    public string? PosterURL { get; set; }

    public int Type { get; set; }
    public int? Category { get; set; }

    public uint? Budget { get; set; }
    public string? BudgetCurrency { get; set; }
    public uint? FeesRussia { get; set; }
    public string? FeesRussiaCurrency { get; set; }
    public uint? FeesUsa { get; set; }
    public string? FeesUsaCurrency { get; set; }
    public uint? FeesWorld { get; set; }
    public string? FeesWorldCurrency { get; set; }

    public int[] Countries { get; set; }
    public int[] Genres { get; set; }

    public SeasonsInfoForMoviePageDto[]? Seasons { get; set; }
    public InsertPersonDto[] People { get; set; }
}
