using Contracts.Shared;
using DotNetflix.Application.Features.Users.Queries.GetUserId;
using DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;
using DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllFilmNamesInSubscription;
using DotNetflix.Application.Features.Subscriptions.Queries.GetAllSubscriptionsForUser;
using DotNetflix.Application.Features.Subscriptions.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SubscriptionController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<AvailableSubscriptionDto>> GetAllSubscriptionsAsync()
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        var getAllSubscriptionsForUserQuery = new GetAllSubscriptionsForUserQuery(userId);
        
        return await _mediator.Send(getAllSubscriptionsForUserQuery);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllFilmNamesAsync([FromQuery] int subscriptionId)
    {
        var query = new GetAllFilmNamesInSubscriptionQuery(subscriptionId);
        var result = await _mediator.Send(query);
        return result.Match<IActionResult>(
            Ok,
            BadRequest);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PurchaseAsync([FromQuery] int subscriptionId, [FromBody] CardDataDto cardDataDto)
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        if (userId is null)
            return BadRequest();
        
        var command = new PurchaseSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            x => Ok(x),
            BadRequest);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> ExtendAsync([FromQuery] int subscriptionId, [FromBody] CardDataDto cardDataDto)
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        if (userId is null)
            return BadRequest();
        
        var command = new ExtendSubscriptionCommand(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
        var result = await _mediator.Send(command);
        return result.Match<IActionResult>(
            x => Ok(x),
            BadRequest);
    }
}