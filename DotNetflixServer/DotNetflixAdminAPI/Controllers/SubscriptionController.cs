using Contracts.Admin.DataRepresentation;
using Contracts.Admin.Subscriptions;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Services.Admin.Abstractions;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("[action]")]
    public async Task<int> GetSubscriptionsCountAsync()
    {
        return await _subscriptionService.GetSubscriptionsCountAsync();
    }

    [HttpGet("[action]")]
    public async Task<PaginationDataDto<SubscriptionDto>> GetAllAsync([FromQuery] string? name, [FromQuery] int? page = 1)
    {
        return await _subscriptionService.GetSubscriptionsFilteredAsync(name, page!.Value);
    }

    [HttpGet("[action]")]
    public IEnumerable<FilmInSubscriptionDto> GetAllFilmsAsync([FromQuery] int subscriptionId, [FromQuery] string? name)
    {
        return _subscriptionService.GetAllFilms(subscriptionId, name);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateFilmsInSubscriptionAsync([FromQuery] int subscriptionId, [FromBody] IDictionary<int, bool> movies)
    {
        try
        {
            await _subscriptionService.UpdateFilmsInSubscriptionAsync(subscriptionId, movies);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPost("[action]")]
    public async Task AddAsync([FromBody] AddSubscriptionDto dto)
    {
        await _subscriptionService.AddSubscriptionAsync(dto);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSubscriptionDto dto)
    {
        try
        {
            await _subscriptionService.UpdateSubscriptionAsync(dto);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Delete([FromQuery] int subscriptionId)
    {
        try
        {
            await _subscriptionService.DeleteSubscription(subscriptionId);
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
    public async Task<IActionResult> ChangeAvailabilityAsync([FromBody] SubscriptionAvailabilityDto dto)
    {
        try
        {
            await _subscriptionService.ChangeSubscriptionAvailabilityAsync(dto);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}