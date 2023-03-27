using DataAccess.Entities.IdentityLogic;
using DtoLibrary;

namespace Services.Mappers
{
    public static class UserToDto
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Login = user.UserName,
                Email = user.Email,
                Birthdate = user.Birthday,
                Enabled2FA = user.TwoFactorEnabled
            };
        }
    }
}
