using System.Security.Claims;
using Contracts.Messages;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace DotNetflixAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IChatStorage _chatStorage;

    public MessageController(IChatStorage chatStorage)
    {
        _chatStorage = chatStorage;
    }

    [HttpGet("[action]")]
    public IEnumerable<MessageDto> GetAll()
    {
        return _chatStorage.GetAllMessages()
            .Select(m => new MessageDto(
                Message: m.Message,
                SenderName: m.SenderName,
                SendingDate: m.SendingDate,
                BelongsToSender: m.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)));
    }
}