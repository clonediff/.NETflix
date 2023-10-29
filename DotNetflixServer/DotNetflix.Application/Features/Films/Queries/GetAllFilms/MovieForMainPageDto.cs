namespace DotNetflix.Application.Features.Films.Queries.GetAllFilms;

public record MovieForMainPageDto(int Id, string Name, double? Rating, string PosterUrl, string Category);
