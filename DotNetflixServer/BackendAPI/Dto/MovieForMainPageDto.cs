namespace BackendAPI.Dto;

public class MovieForMainPageDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double? Rating { get; set; }
    public string PosterUrl { get; set; }
    public string Category { get; set; }
}