using Domain.Entities;

namespace DotNetflix.Application.Shared.Mapping;

public static class UserToDto
{
    public static UserDto ToUserDto(this User user)
    {
        return new UserDto
        (
            Login: user.UserName!,
            Email: user.Email!,
            Birthdate: user.Birthday,
            Enabled2FA: user.TwoFactorEnabled
        );
    }
}
