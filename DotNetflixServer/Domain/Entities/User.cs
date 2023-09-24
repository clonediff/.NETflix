using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
    public DateTime? BannedUntil { get; set; }
    public List<UserSubscription> UserSubscriptions { get; set; } = null!;
    public List<Subscription> Subscriptions { get; set; } = null!;
}
