using DtoLibrary;
using Microsoft.AspNetCore.Mvc;
using Services.Exceptions;
using Services.SubscriptionService;
using Services.UserService;

namespace BackendAPI.Controllers;

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
    public IEnumerable<AvailableSubscriptionDto> GetAllSubscriptions()
    {
        return _subscriptionService.GetAllSubscriptions();
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllUserSubscriptionsAsync()
    {
        var userId = await _userService.GetUserIdAsync(User);
        
        try
        {
            var subscriptions = await _subscriptionService.GetAllUserSubscriptionsAsync(userId);
            return Ok(subscriptions);
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
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
        
        try
        {
            await _subscriptionService.PurchaseSubscriptionAsync(new UserSubscriptionDto
            {
                SubscriptionId = subscriptionId,
                UserId = userId
            }, cardDataDto);
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
        
        try
        {
            await _subscriptionService.ExtendSubscriptionAsync(new UserSubscriptionDto
            {
                SubscriptionId = subscriptionId,
                UserId = userId
            }, cardDataDto);
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