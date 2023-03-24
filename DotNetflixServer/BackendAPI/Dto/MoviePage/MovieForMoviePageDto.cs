using DBModels.BusinessLogic;

namespace BackendAPI.Dto
{
    public class MovieForMoviePageDto
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
		public string Type { get; set; }
		public string? Category { get; set; }
		public string? Budget { get; set; }
		public FeesForMoviePageDto? Fees { get; set; }
		public List<string> Countries { get; set; }
		public List<string> Genres { get; set; }
		public List<SeasonsInfoForMoviePageDto> SeasonsInfo { get; set; }
		public List<PersonForMoviePageDto> Proffessions { get; set; }
    }
}
