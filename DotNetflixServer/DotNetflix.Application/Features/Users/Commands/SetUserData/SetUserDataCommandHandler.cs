using Domain.Entities;
using DotNetflix.Application.Shared.Mapping;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Application.Features.Users.Commands.SetUserData;

internal class SetUserDataCommandHandler : ICommandHandler<SetUserDataCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;

    public SetUserDataCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result<string, string>> Handle(SetUserDataCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.GetUserAsync(request.User);
        user!.UserName = request.UserName;
        user.Birthday = request.Birthdate;
        var changeRes = await _userManager.UpdateAsync(user);
        return changeRes.ToResult("Данные изменены");
    }
}
