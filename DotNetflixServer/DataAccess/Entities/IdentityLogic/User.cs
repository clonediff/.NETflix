using Microsoft.AspNetCore.Identity;

namespace DataAccess.Entities.IdentityLogic;

public class User : IdentityUser
{
    public DateTime Birthday { get; set; }
}
