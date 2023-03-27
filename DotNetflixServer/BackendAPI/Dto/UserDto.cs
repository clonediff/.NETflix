using DBModels.IdentityLogic;

namespace BackendAPI.Dto
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public bool Enabled2FA { get; set; }
        public Role Role { get; set; }
    }
}
