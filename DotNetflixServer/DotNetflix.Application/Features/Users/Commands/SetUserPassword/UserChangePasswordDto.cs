namespace DotNetflix.Application.Features.Users.Commands.SetUserPassword;

public record UserChangePasswordDto(string Password, string Token);
