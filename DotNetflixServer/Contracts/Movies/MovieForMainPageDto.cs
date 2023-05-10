namespace Contracts.Movies;

public record MovieForMainPageDto(int Id, string Name, double? Rating, string PosterUrl, string Category);