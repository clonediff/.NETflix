namespace Domain.Entities;

public class MovieInfo
{
	public int Id { get; set; }
	public string Name { get; set; } = null!;               // maxLength = 50
	public int Year { get; set; }
	public string? Description { get; set; }
	public string? ShortDescription { get; set; }
	public string? Slogan { get; set; }
	public double? Rating { get; set; }
	public int MovieLength { get; set; }
	public int? AgeRating { get; set; }
	public string? PosterURL { get; set; } 
	public int TypeId { get; set; }
	public Types Type { get; set; } = null!;
	public int? CategoryId { get; set; }
	public Category? Category { get; set; }
	public int? BudgetId { get; set; }
	public CurrencyValue? Budget { get; set; }
	public int? FeesId { get; set; }
	public Fees Fees { get; set; } = null!;
	public List<CountryMovieInfo> Countries { get; set; } = null!;
	public List<GenreMovieInfo> Genres { get; set; } = null!;
	public List<SeasonsInfo>? SeasonsInfo { get; set; }
	public List<PersonProffessionInMovie> Proffessions { get; set; } = null!;
	public List<Subscription> Subscriptions { get; set; } = null!;
}