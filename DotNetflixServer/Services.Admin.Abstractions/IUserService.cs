using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Users;

namespace Services.Admin.Abstractions;

public interface IUserService
{
    Task<int> GetUsersCountAsync();
    IEnumerable<EnumDto<string>> GetAllRoles();
    Task<PaginationDataDto<UserDto>> GetUsersFilteredAsync(int page, string? name);
}