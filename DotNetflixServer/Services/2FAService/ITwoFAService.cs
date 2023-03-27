using DataAccess.Entities.IdentityLogic;

namespace Services.TwoFAService
{
    public interface ITwoFAService
    {
        public Task SendCodeAsync(User user);
        public bool CheckCode(User user, string code);
    }
}
