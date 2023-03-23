using Microsoft.AspNetCore.Identity;

namespace DBModels.IdentityLogic
{
    public class User : IdentityUser
    {
        public DateTime Birthday { get; set; }
    }
}
