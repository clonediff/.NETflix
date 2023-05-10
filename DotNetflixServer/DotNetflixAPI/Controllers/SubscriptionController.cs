using Contracts;
using Contracts.Subscriptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly IUserService _userService;

    public SubscriptionController(ISubscriptionService subscriptionService, IUserService userService)
    {
        _subscriptionService = subscriptionService;
        _userService = userService;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<AvailableSubscriptionDto>> GetAllSubscriptionsAsync()
    {
        var userId = await _userService.GetUserIdAsync(User);

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
        var userId = await _userService.GetUserIdAsync(User);
        
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
        var userId = await _userService.GetUserIdAsync(User);
        
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