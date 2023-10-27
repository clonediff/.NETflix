using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
    public DateTime? BannedUntil { get; set; }
    public List<UserSubscription> UserSubscriptions { get; set; } = null!;
    public List<Subscription> Subscriptions { get; set; } = null!;
    public List<Message> Messages { get; set; } = default!;
    public List<UserChatMessage> UserChatMessages { get; set; } = default!;
}
