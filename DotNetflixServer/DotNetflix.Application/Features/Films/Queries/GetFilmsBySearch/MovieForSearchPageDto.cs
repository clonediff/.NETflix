namespace DotNetflix.Application.Features.Films.Queries.GetFilmsBySearch;

public record MovieForSearchPageDto(int Id, string Name, double? Rating, string PosterUrl);
