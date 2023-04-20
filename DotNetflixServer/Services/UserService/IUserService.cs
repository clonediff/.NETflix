using System.Security.Claims;
using DataAccess.Entities.IdentityLogic;
using DtoLibrary;

namespace Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserAsync(ClaimsPrincipal claimsPrincipal);
        Task<string> GetEmailAsync(string userId);
        IEnumerable<GetRoleDto> GetAllRoles();
        Task<int> GetUsersCountAsync();
        IEnumerable<UserAdminDto> GetUsersFiltered(int page, string? name);
        Task<string> SetRoleAsync(string roleId, string userId);
        Task<DateTime> BanUserAsync(string userId, int days);
        Task UnbanUserAsync(string userId);
    }
}