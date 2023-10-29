namespace DotNetflix.Admin.Application.Features.Users.Queries.GetUsersFiltered;

public record UserDto(string Id, string Name, DateTime? BannedUntil, string RoleId);