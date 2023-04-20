namespace DataAccess.Entities.BusinessLogic;

public class UserSubscription
{
    public string UserId { get; set; }
    public int SubscriptionId { get; set; }
    public DateTime? Expires { get; set; }
}