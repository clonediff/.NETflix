using DataAccess.Entities.BusinessLogic;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities.IdentityLogic;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
    public DateTime? BannedUntil { get; set; }
    public List<UserSubscription> UserSubscriptions { get; set; }
    public List<Subscription> Subscriptions { get; set; }
}
