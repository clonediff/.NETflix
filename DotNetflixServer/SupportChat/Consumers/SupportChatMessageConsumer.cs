using Contracts.Shared;
using Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace SupportChat.Consumers;

public class SupportChatMessageConsumer : IConsumer<SupportChatMessage>
{
    private readonly DbContext _context;

    public SupportChatMessageConsumer(DbContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<SupportChatMessage> context)
    {
        var isMessageDuplicated = _context
            .Set<Message>()
            .Where(x => x.UserId == context.Message.RoomId
                && x.Content == context.Message.Content)
                .AsEnumerable()
            .Any(x => $"{x.SendingDate:s}" == $"{context.Message.SendingDate:s}");

        if (isMessageDuplicated) return;

        var message = new Message
        {
            SendingDate = context.Message.SendingDate,
            IsFromAdmin = context.Message.IsFromAdmin,
            UserId = context.Message.RoomId,
            Content = context.Message.Content,
            IsRead = context.Message.IsReadByAdmin
        };

        _context.Set<Message>().Add(message);
        await _context.SaveChangesAsync();
    }
}
