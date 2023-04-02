using Microsoft.AspNetCore.Mvc;

namespace BackendAPI;

public class QueryStringDto
{
    public string? Type { get; set; }
    public string? Name { get; set; }
    public int? Year { get; set; }
    public string? Country { get; set; }
    [FromQuery(Name = "genre")]
    public string[]? Genres { get; set; }
    [FromQuery(Name = "actor")]
    public string[]? Actors { get; set; }
    public string? Director { get; set; }
}