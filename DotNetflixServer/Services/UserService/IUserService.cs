using DtoLibrary;

namespace Services.UserService
{
    public interface IUserService
    {
        IEnumerable<GetRoleDto> GetAllRoles();
        Task<int> GetUsersCountAsync();
        IEnumerable<UserAdminDto> GetUsersFiltered(int page, string? name);
        Task SetRoleAsync(string roleId, string userId);
        Task<DateTime> BanUserAsync(string userId, int days);
        Task UnbanUserAsync(string userId);
    }
}