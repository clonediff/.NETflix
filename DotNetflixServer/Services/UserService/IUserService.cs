using DtoLibrary;
using Microsoft.AspNetCore.Mvc;

namespace Services.UserService
{
    public interface IUserService
    {
        Task<int> GetUsersCountAsync();
        IEnumerable<UserAdminDto> GetUsersFiltered(int page, string? name);
        Task<IActionResult> SetRoleAsync(string role, string userId);
        Task<IActionResult> BanUserAsync(string userId, int days);
        Task<IActionResult> UnbanUserAsync(string userId);
    }
}