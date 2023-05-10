namespace Contracts.Admin.Users;

public record UserDto(string Id, string Name, DateTime? BannedUntil, string RoleId);