namespace DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

public record MovieSearchDto(
    string? Type, 
    string? Name, 
    int? Year, 
    string? Country, 
    string[]? Genres, 
    string[]? Actors, 
    string? Director);