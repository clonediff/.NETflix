using Domain.Entities;
using DotNetflix.CQRS;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Services.Shared.JwtGenerator;

namespace DotNetflix.Application.Features.JwtAuthentication.Commands.Login;

public class JwtLoginCommandHandler : IRequestHandler<JwtLoginCommand, Result<string, string>>
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtGenerator _jwtGenerator;
    
    public JwtLoginCommandHandler(UserManager<User> userManager,  
        SignInManager<User> signInManager,
        IJwtGenerator jwtGenerator)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerator = jwtGenerator;
    }
    
    public async Task<Result<string, string>> Handle(JwtLoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(request.Username);
        if (user == null)
        
            return new Result<string, string>(failure: "Неверный логин или пароль!");
        
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        return !result.Succeeded 
            ? new Result<string, string>(failure: "Неверный логин или пароль!") 
            : new Result<string, string>(success: _jwtGenerator.GenerateToken(user));
    }
}