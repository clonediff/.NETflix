namespace Contracts;

public record UserDto(string Login, string Email, DateTime Birthdate, bool Enabled2FA);