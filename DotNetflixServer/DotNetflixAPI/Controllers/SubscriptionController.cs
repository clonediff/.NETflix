using Contracts;
using Contracts.Subscriptions;
using Domain.Exceptions;
using DotNetflix.Application.Features.User.Queries.GetUserId;
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
    private readonly ISubscriptionService _subscriptionService;
    private readonly IMediator _mediator;

    public SubscriptionController(ISubscriptionService subscriptionService, IMediator mediator)
    {
        _subscriptionService = subscriptionService;
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<AvailableSubscriptionDto>> GetAllSubscriptionsAsync()
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        return _subscriptionService.GetAllSubscriptions(userId);
    }

    [HttpGet("[action]")]
    public IAsyncEnumerable<string> GetAllFilmNames([FromQuery] int subscriptionId)
    {
        return _subscriptionService.GetAllFilmNames(subscriptionId);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> PurchaseAsync([FromQuery] int subscriptionId, [FromBody] CardDataDto cardDataDto)
    {
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        if (userId is null)
            return BadRequest();
        
        try
        {
            await _subscriptionService.PurchaseSubscriptionAsync(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
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
        var getUserIdQuery = new GetUserIdQuery(User);
        var userId = await _mediator.Send(getUserIdQuery);
        
        if (userId is null)
            return BadRequest();
        
        try
        {
            await _subscriptionService.ExtendSubscriptionAsync(new UserSubscriptionDto(userId, subscriptionId), cardDataDto);
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