namespace DtoLibrary;

public class UpdateSubscriptionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int? PeriodInDays { get; set; }
}