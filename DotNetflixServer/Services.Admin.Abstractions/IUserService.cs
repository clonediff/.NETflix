using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Users;

namespace Services.Admin.Abstractions;

public interface IUserService
{
    Task<int> GetUsersCountAsync();
    IEnumerable<EnumDto<string>> GetAllRoles();
    Task<PaginationDataDto<UserDto>> GetUsersFilteredAsync(int page, string? name);
    Task<string> SetRoleAsync(SetRoleDto dto);
    Task<string> GetEmailAsync(string userId);
    Task<DateTime> BanUserAsync(BanUserDto dto);
    Task UnbanUserAsync(string userId);
}