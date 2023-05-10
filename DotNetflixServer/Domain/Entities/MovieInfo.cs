namespace Domain.Entities;

public class MovieInfo
{
	public int Id { get; set; }
	public string Name { get; set; }                // maxLength = 50
	public int Year { get; set; }
	public string? Description { get; set; }
	public string? ShortDescription { get; set; }
	public string? Slogan { get; set; }
	public double? Rating { get; set; }
	public int MovieLength { get; set; }
	public int? AgeRating { get; set; }
	public string? PosterURL { get; set; }
	public int TypeId { get; set; }
	public Types Type { get; set; }
	public int? CategoryId { get; set; }
	public Category? Category { get; set; }
	public int? BudgetId { get; set; }
	public CurrencyValue? Budget { get; set; }
	public int? FeesId { get; set; }
	public Fees Fees { get; set; }
	public List<CountryMovieInfo> Countries { get; set; }
	public List<GenreMovieInfo> Genres { get; set; }
	public List<SeasonsInfo>? SeasonsInfo { get; set; }
	public List<PersonProffessionInMovie> Proffessions { get; set; }
	public List<Subscription> Subscriptions { get; set; }
}