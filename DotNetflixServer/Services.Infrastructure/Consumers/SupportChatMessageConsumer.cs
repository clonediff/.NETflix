using Contracts.Shared;
using DataAccess;
using Domain.Entities;
using MassTransit;

namespace Services.Infrastructure.Consumers;

public class SupportChatMessageConsumer : IConsumer<SupportChatMessage>
{
    private readonly ApplicationDBContext _context;

    public SupportChatMessageConsumer(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task Consume(ConsumeContext<SupportChatMessage> context)
    {
        var message = new Message
        {
            SendingDate = context.Message.SendingDate,
            IsFromAdmin = context.Message.IsFromAdmin,
            UserId = context.Message.RoomId,
            Content = context.Message.Content,
            IsRead = context.Message.IsReadByAdmin
        };

        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
    }
}
