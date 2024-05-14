using System.Text.RegularExpressions;
using Configuration.Shared;
using Contracts.Shared;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Shared.SupportChatService;

public partial class SupportChatService : ISupportChatService
{
    private readonly DbContext _context;
    private readonly HttpClient _httpClient;
    private const string AdminName = "Администратор";

    public SupportChatService(DbContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<dynamic>> GetHistoryAsync(string roomId, bool senderIsAdmin)
    {
        var messages = _context.Set<Message>()
            .Where(x => x.UserId == roomId)
            .Include(x => x.User)
            .AsEnumerable();
            
        return await Task.WhenAll(messages
            .Select(x => CreateMessageAsync(roomId, x, senderIsAdmin == x.IsFromAdmin)));
    }

    private async Task<dynamic> CreateMessageAsync(string roomId, Message message, bool belongsToSender)
    {
        if (FileRegex().IsMatch(message.Content))
        {
            return await CreateFileMessageAsync(roomId, message, belongsToSender);
        }
        
        return new SupportChatMessageDto<string>(
            roomId, 
            SupportChatMessageType.Text, 
            message.Content, 
            message.IsFromAdmin ? AdminName : message.User.UserName!, 
            message.SendingDate, 
            belongsToSender
        );
    }

    private async Task<SupportChatMessageDto<ImageDto>> CreateFileMessageAsync(string roomId, Message message, bool belongsToSender)
    {
        var parts = message.Content.Split('_');
        var bucketName = parts[1];
        var fileName = parts[2];
        var contentType = parts[3];
        await using var imageStream = await _httpClient.GetStreamAsync($"/api/files/{bucketName}/{fileName}");
        var memoryStream = new MemoryStream();

        await imageStream.CopyToAsync(memoryStream);

        var image = new ImageDto($"data:{contentType};base64,", memoryStream.ToArray());
            
        return new SupportChatMessageDto<ImageDto>(
            roomId, 
            SupportChatMessageType.File,
            image, 
            message.IsFromAdmin ? AdminName : message.User.UserName!, 
            message.SendingDate, 
            belongsToSender
        );
    }

    [GeneratedRegex(@"file_.+_.+_.+\/.+")]
    private static partial Regex FileRegex();
}
