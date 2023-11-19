using System.Text.RegularExpressions;
using Contracts.Shared;
using DataAccess;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Shared.SupportChatService;

public partial class SupportChatService : ISupportChatService
{
    private readonly ApplicationDBContext _context;
    private readonly HttpClient _httpClient;
    private const string AdminName = "Администратор";

    public SupportChatService(ApplicationDBContext context, HttpClient httpClient)
    {
        _context = context;
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<dynamic>> GetHistoryAsync(string roomId, bool senderIsAdmin)
    {
        var messages = _context.Messages
            .Where(x => x.UserId == roomId)
            .Include(x => x.User)
            .AsEnumerable();
            
        return await Task.WhenAll(messages
            .Select(x => CreateMessageAsync(x, senderIsAdmin == x.IsFromAdmin)));
    }

    private async Task<dynamic> CreateMessageAsync(Message message, bool belongsToSender)
    {
        if (FileRegex().IsMatch(message.Content))
        {
            return await CreateFileMessageAsync(message, belongsToSender);
        }
        
        return new MessageDto<string>(message.Content, message.IsFromAdmin ? AdminName : message.User.UserName!, message.SendingDate, belongsToSender);
    }

    private async Task<MessageDto<ImageDto>> CreateFileMessageAsync(Message message, bool belongsToSender)
    {
        var parts = message.Content.Split('_');
        var bucketName = parts[1];
        var fileName = parts[2];
        var contentType = parts[3];
        await using var imageStream = await _httpClient.GetStreamAsync($"/api/files/{bucketName}/{fileName}");
        var memoryStream = new MemoryStream();

        await imageStream.CopyToAsync(memoryStream);

        var image = new ImageDto($"data:{contentType};base64,", memoryStream.ToArray());
            
        return new MessageDto<ImageDto>(image, message.IsFromAdmin ? AdminName : message.User.UserName!, message.SendingDate, belongsToSender);
    }

    [GeneratedRegex(@"file_.+_.+_.+\/.+")]
    private static partial Regex FileRegex();
}
