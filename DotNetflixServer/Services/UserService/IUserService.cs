using System.Security.Claims;
using DtoLibrary;

namespace Services.UserService
{
    public interface IUserService
    {
        Task<int> GetUsersCountAsync();
        Task<string?> GetUserIdAsync(ClaimsPrincipal claimsPrincipal);
        Task<IEnumerable<int>> GetAvailableFilmIdsAsync(string? userId);
        Task<string> GetEmailAsync(string userId);
        IEnumerable<GetUserSubscriptionDto> GetAllUserSubscriptions(string userId);
        IEnumerable<GetRoleDto> GetAllRoles();
        Task<PaginationDataDto<UserAdminDto>> GetUsersFilteredAsync(int page, string? name);
        Task<string> SetRoleAsync(string roleId, string userId);
        Task<DateTime> BanUserAsync(string userId, int days);
        Task UnbanUserAsync(string userId);
    }
}