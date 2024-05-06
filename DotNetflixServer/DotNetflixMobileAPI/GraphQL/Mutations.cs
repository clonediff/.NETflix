using Contracts.Shared;
using Domain.Entities;
using DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;
using DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;
using DotNetflix.Application.Features.Subscriptions.Shared;
using DotNetflix.Application.Features.TwoFactorAuthorization.Commands.EnableTwoFactorAuth;
using DotNetflix.Application.Features.Users.Commands.SetUserData;
using DotNetflix.Application.Features.Users.Commands.SetUserMail;
using DotNetflix.Application.Features.Users.Commands.SetUserPassword;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflixMobileAPI.GraphQL.Models;
using GraphQL;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Services.Infrastructure.EmailService;

namespace DotNetflixMobileAPI.GraphQL;

public enum SubscriptionActionType
{
    Purchase,
    Extend   
}

public class Mutations
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public Mutations(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    [Authorize]
    public async Task<GraphQLResponse> SubscriptionAction(SubscriptionActionType type, int subscriptionId, CardDataDto cardDataDto)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var userId = httpContext!.Request.Headers.Authorization.ToString();

        if (userId is null)
        {
            return "Неверный идентификатор пользователя";
        }

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        ICommand<Result<int, string>> command = type switch
        {
            SubscriptionActionType.Purchase => new PurchaseSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto),
            SubscriptionActionType.Extend => new ExtendSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto),
            _ => throw new NotImplementedException(),
        };
        var result = await mediator.Send(command);

        return result.Match(
            _ => new GraphQLResponse(false),
            x => new GraphQLResponse(true, x)
        );
    }

    public async Task<string> SetUserPasswordAsync(UserChangePasswordDto chPass)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;

        var user = await userManager.GetUserAsync(context.User);
        var command = new SetUserPasswordCommand(user!, chPass.Password, UserManager<User>.ResetPasswordTokenPurpose,
            chPass.Token);
        var result = await mediator.Send(command);
        return result.Match(
            success: s => s, 
            failure: f => throw new Exception(f));
    }

    public async Task<string> SetUserMailAsync(UserChangeMailDto chMail)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;

        var user = await userManager.GetUserAsync(context.User);
        var command = new SetUserMailCommand(user!, chMail.Email,
            UserManager<User>.GetChangeEmailTokenPurpose(chMail.Email), chMail.Token);
        var result = await mediator.Send(command);
        return result.Match(
            success: s => s,
            failure: f => throw new Exception(f));
    }

    public async Task<string> SetUserDataAsync(UserChangeOrdinaryDto chOrdinary)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;
        
        var command = new SetUserDataCommand(context.User, chOrdinary.Birthdate, chOrdinary.UserName);
        var result = await mediator.Send(command);
        return result.Match(
            success: s => s,
            failure: f => throw new Exception(f));
    }
    
    public async Task<string> Enable2FAAsync(EnableTwoFactorAuthDto dto)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;
        
        var user = await userManager.GetUserAsync(context.User);
        var command = new EnableTwoFactorAuthCommand(user!, UserManager<User>.ConfirmEmailTokenPurpose, dto.Token);
        var result = await mediator.Send(command);
        
        return result.Match(
            success: s => s,
            failure: f => throw new Exception(f));
    }
    
    public async Task<string> Send2FATokenAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
        
        var user = await userManager.GetUserAsync(context.User);
        var code = await userManager.GenerateEmailConfirmationTokenAsync(user!);
        await emailService.SendEmailAsync(user!.Email!, "Код для двухфакторной аутентификации", code);
        return $"Код для двухфакторной аутентификации отправлен на почту {user.Email}";
    }
    
    public async Task<string> SendChangePasswordTokenAsync()
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
        
        var user = await userManager.GetUserAsync(context.User);
        var code = await userManager.GeneratePasswordResetTokenAsync(user!);
        await emailService.SendEmailAsync(user!.Email!, "Код для изменения пароля", code);
        
        return $"Код для изменения пароля отправлен на почту {user.Email}";
    }

    public async Task<string> SendChangeMailTokenAsync(string newEmail)
    {
        using var scope = _serviceScopeFactory.CreateScope();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
        var context = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
        
        var user = await userManager.GetUserAsync(context.User);
        var code = await userManager.GenerateChangeEmailTokenAsync(user!, newEmail);
        await emailService.SendEmailAsync(user!.Email!, $"Код для изменения почты с {user.Email} на {newEmail}", code);

        return $"Код для изменения почты с {user.Email} на {newEmail} отправлен на почту {user.Email}";
    }
}