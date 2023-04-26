namespace DtoLibrary;

public class SubscriptionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
    public bool IsAvailable { get; set; }
    public int SubscribersCount { get; set; }
}