namespace Domain.Entities;

public class GenreMovieInfo
{
	public int GenreId { get; set; }
	public int MovieInfoId { get; set; }
	public Genre Genre { get; set; } = null!;
}