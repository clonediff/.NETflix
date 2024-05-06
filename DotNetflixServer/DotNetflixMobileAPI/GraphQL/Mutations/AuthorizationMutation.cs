using DotNetflix.Application.Features.JwtAuthentication.Commands.Login;
using DotNetflix.Application.Features.JwtAuthentication.Commands.Register;
using DotNetflixMobileAPI.GraphQL.Models;
using MediatR;

namespace DotNetflixMobileAPI.GraphQL.Mutations;

public class AuthorizationMutation
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AuthorizationMutation(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<GraphQLResponse<string>> Login(LoginForm form)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var command = new JwtLoginCommand(form.UserName, form.Password, form.Remember);
        var result = await mediator.Send(command);
        return result;
    }

    public async Task<GraphQLResponse> Register(RegisterForm form)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var command = new RegisterCommand(form.Email, form.Birthday, form.UserName, form.Password, form.ConfirmPassword);
        var result = await mediator.Send(command);
        return result.Match(_ => new GraphQLResponse(false), f => new GraphQLResponse(true, f));
    }
}