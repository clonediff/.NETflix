namespace DataAccess.Entities.BusinessLogic;

public class SeasonsInfo
{
	public int Id { get; set; }
	public int Number { get; set; }
	public int EpisodesCount { get; set; }
	public int MovieInfoId { get; set; }
	public MovieInfo MovieInfo { get; set; }
}