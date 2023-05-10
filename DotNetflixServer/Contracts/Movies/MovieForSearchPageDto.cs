namespace Contracts.Movies;

public record MovieForSearchPageDto(int Id, string Name, double? Rating, string PosterUrl);