namespace Domain.Entities;

public class CountryMovieInfo
{
	public int MovieInfoId { get; set; }
	public int CountryId { get; set; }
	public Country Country { get; set; }
}