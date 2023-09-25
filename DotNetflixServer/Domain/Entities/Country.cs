namespace Domain.Entities;

public class Country
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;
	public string Slug { get; set; } = null!;
    public double Lat { get; set; }
    public double Lng { get; set; }
	public List<CountryMovieInfo> Movies { get; set; } = null!;
}