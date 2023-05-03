namespace DtoLibrary;

public class AvailableSubscriptionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
    public IEnumerable<string> FilmNames { get; set; }
}