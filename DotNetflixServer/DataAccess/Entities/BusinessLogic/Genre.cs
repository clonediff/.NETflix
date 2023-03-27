namespace DataAccess.Entities.BusinessLogic;

public class Genre
{
	public int Id { get; set; }
	public string Name { get; set; }    // maxLength = 20
	public string Slug { get; set; }    // maxLength = 20
	public List<GenreMovieInfo> Movies { get; set; }
}