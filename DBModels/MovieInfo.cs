namespace DBModels
{
	public class MovieInfo
	{
		public uint Id { get; set; }
		public string Name { get; set; }
		public int Year { get; set; }
		public string? Description { get; set; }
		public string? ShortDescription { get; set; }
		public string? Slogan { get; set; }
		public double? Rating { get; set; }
		public int? MovieLength { get; set; }
		public int? AgeRating { get; set; }
		public string? PosterURL { get; set; }
		public Types Type { get; set; }
		public CurrencyValue? Budget { get; set; }
		public Fees Fees { get; set; }
		public Country[] Countries { get; set; }
		public Genre[] Genres { get; set; }
		public SeasonsInfo[]? SeasonsInfo { get; set; }
		public PersonProffessionInMovie[] Proffessions { get; set; }
	}
}