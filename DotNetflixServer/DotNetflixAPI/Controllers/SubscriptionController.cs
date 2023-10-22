using Contracts.Shared;
using Domain.Exceptions;
using DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;
using DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;
using DotNetflix.Application.Features.Subscriptions.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SubscriptionController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public SubscriptionController(IMediator mediator, IUserService userService)
    {
        _userService = userService;
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<AvailableSubscriptionDto>> GetAllSubscriptionsAsync()
    {
        var userId = await _userService.GetUserIdAsync(User);

        var query = new GetAllSubscriptionsForUserQuery(userId);
        
        return await _mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<string>> GetAllFilmNamesAsync([FromQuery] int subscriptionId)
    {
        var query = new GetAllFilmNamesInSubscriptionQuery(subscriptionId);
        return await _mediator.Send(query);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PurchaseAsync([FromQuery] int subscriptionId, [FromBody] CardDataDto cardDataDto)
    {
        var userId = await _userService.GetUserIdAsync(User);
        
        if (userId is null)
            return BadRequest();
        
        try
        {
            var command = new PurchaseSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
            await _mediator.Send(command);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (IncorrectOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ExtendAsync([FromQuery] int subscriptionId, [FromBody] CardDataDto cardDataDto)
    {
        var userId = await _userService.GetUserIdAsync(User);
        
        if (userId is null)
            return BadRequest();
        
        try
        {
            var command = new ExtendSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
            await _mediator.Send(command);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (IncorrectOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}