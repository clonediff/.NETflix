using DotNetflix.Admin.Application.Features.Users.Commands.BanUser;

namespace DotNetflix.Admin.Application.Features.Users.Mapping;

public static class BanUserDtoToCommand
{
    public static BanUserCommand ToBanUserCommand(this BanUserDto dto)
    {
        return new BanUserCommand(dto.UserId, dto.Days);
    }
}