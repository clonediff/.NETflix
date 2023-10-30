using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

public record GetFilmsBySearchQuery(string? Type, 
    string? Name, 
    int? Year, 
    string? Country, 
    string[]? Genres, 
    string[]? Actors, 
    string? Director) : IQuery<IEnumerable<MovieForSearchPageDto>>;
