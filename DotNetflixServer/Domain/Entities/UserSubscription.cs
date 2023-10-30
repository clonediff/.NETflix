namespace Domain.Entities;

public class UserSubscription
{
    public string UserId { get; set; } = null!;
    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; } = null!;
    public DateTime? Expires { get; set; }
}