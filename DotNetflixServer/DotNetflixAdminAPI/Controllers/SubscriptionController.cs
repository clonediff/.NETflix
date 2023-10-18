using Domain.Exceptions;
using DotNetflix.Admin.Application.Features.Subscriptions.Commands.AddSubscription;
using DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;
using DotNetflix.Admin.Application.Features.Subscriptions.Commands.DeleteSubscription;
using DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateFilmsInSubscription;
using DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;
using DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetAllFilmsInSubscription;
using DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsCount;
using DotNetflix.Admin.Application.Features.Subscriptions.Queries.GetSubscriptionsFiltered;
using DotNetflix.Admin.Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetflixAdminAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Policy = "Manager")]
public class SubscriptionController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubscriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]")]
    public async Task<int> GetSubscriptionsCountAsync()
    {
        var query = new GetSubscriptionsCountQuery();
        return await _mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async Task<PaginationDataDto<GetSubscriptionsFilteredDto>> GetAllAsync([FromQuery] string? name, [FromQuery] int? page = 1, [FromQuery] int? size = 25)
    {
        var query = new GetSubscriptionsFilteredQuery(name, page!.Value, size!.Value);
        return await _mediator.Send(query);
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<GetAllFilmsInSubscriptionDto>> GetAllFilmsAsync([FromQuery] int subscriptionId, [FromQuery] string? name)
    {
        var query = new GetAllFilmsInSubscriptionQuery(subscriptionId, name);
        return await _mediator.Send(query);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateFilmsInSubscriptionAsync([FromQuery] int subscriptionId, [FromBody] IDictionary<int, bool> movies)
    {
        try
        {
            var command = new UpdateFilmsInSubscriptionCommand(subscriptionId, movies);
            await _mediator.Send(command);
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
        var command = new AddSubscriptionCommand(dto.Name, dto.Cost, dto.PeriodInDays);
        await _mediator.Send(command);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSubscriptionDto dto)
    {
        try
        {
            var command = new UpdateSubscriptionCommand(dto.Id, dto.Name, dto.Cost, dto.PeriodInDays);
            await _mediator.Send(command);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> DeleteAsync([FromQuery] int subscriptionId)
    {
        try
        {
            var command = new DeleteSubscriptionCommand(subscriptionId);
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
    public async Task<IActionResult> ChangeAvailabilityAsync([FromBody] ChangeSubscriptionAvailabilityDto dto)
    {
        try
        {
            var command = new ChangeSubscriptionAvailabilityCommand(dto.Id, dto.IsAvailable);
            await _mediator.Send(command);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}