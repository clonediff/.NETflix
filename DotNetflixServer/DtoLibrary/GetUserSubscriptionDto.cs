namespace DtoLibrary;

public class GetUserSubscriptionDto
{
    public int Id { get; set; }
    public string SubscriptionName { get; set; }
    public int Cost { get; set; }
    public DateTime? Expires { get; set; }
}