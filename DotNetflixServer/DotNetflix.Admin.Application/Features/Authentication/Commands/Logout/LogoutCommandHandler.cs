using Domain.Entities;
using DotNetflix.Abstractions.Cqrs;
using Microsoft.AspNetCore.Identity;

namespace DotNetflix.Admin.Application.Features.Authentication.Commands.Logout;

public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
{
    private readonly SignInManager<User> _signInManager;

    public LogoutCommandHandler(SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
    }

    public Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    { 
        return _signInManager.SignOutAsync();
    }
}