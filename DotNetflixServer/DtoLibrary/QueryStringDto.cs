namespace DtoLibrary;

public class QueryStringDto
{
    public string? Type { get; set; }
    public string? Name { get; set; }
    public int? Year { get; set; }
    public string? Country { get; set; }
    public string[]? Genres { get; set; }
    public string[]? Actors { get; set; }
    public string? Director { get; set; }
}