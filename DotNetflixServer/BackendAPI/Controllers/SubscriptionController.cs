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
    public async Task<IActionResult> Purchase([FromQuery] int subscriptionId)
    {
        try
        {
            var user = await _userService.GetUserAsync(User);
            await _subscriptionService.PurchaseSubscriptionAsync(new SubscriptionDto
            {
                SubscriptionId = subscriptionId,
                UserId = user.Id
            });
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
    public async Task<IActionResult> Extend([FromQuery] int subscriptionId)
    {
        try
        {
            var user = await _userService.GetUserAsync(User);
            await _subscriptionService.ExtendSubscriptionAsync(new SubscriptionDto
            {
                SubscriptionId = subscriptionId,
                UserId = user.Id
            });
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