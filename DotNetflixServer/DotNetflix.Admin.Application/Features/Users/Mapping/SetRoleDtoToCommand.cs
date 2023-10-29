using DotNetflix.Admin.Application.Features.Users.Commands.SetRole;

namespace DotNetflix.Admin.Application.Features.Users.Mapping;

public static class SetRoleDtoToCommand
{
    public static SetRoleCommand ToSetRoleCommand(this SetRoleDto dto)
    {
        return new SetRoleCommand(dto.UserId, dto.RoleId);
    }
}