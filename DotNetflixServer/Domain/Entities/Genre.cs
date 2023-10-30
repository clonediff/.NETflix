namespace Domain.Entities;

public class Genre
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;   // maxLength = 20
	public string Slug { get; set; } = null!;   // maxLength = 20
	public List<GenreMovieInfo> Movies { get; set; } = null!;
}