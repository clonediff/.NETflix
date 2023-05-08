namespace DtoLibrary;

public class AddSubscriptionDto
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
}