using Contracts.Shared;
using Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using static SupportChat.DuplicatedMessagesStore;

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
        if (!string.IsNullOrEmpty(context.Message.UniqueKey))
        {
            DuplicatedMessages.AddOrUpdate(
                key: context.Message.UniqueKey,
                addValue: (1, context.Message),
                updateValueFactory: (_, value) => (++value.count, value.message)  
            );

            if (DuplicatedMessages[context.Message.UniqueKey].count == 1) return;
        }

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

        RemoveDuplicates(context.Message.UniqueKey);
    }
}
