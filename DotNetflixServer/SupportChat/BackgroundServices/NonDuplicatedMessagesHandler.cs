using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using static SupportChat.DuplicatedMessagesStore;

namespace SupportChat.BackgroundServices;

public class NonDuplicatedMessagesHandler : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NonDuplicatedMessagesHandler(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(2));

            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();

            var keys = DuplicatedMessages.Where(kvp => 
                kvp.Value.count == 1 && 
                DateTime.Now - kvp.Value.message.SendingDate > TimeSpan.FromMinutes(1)
            );

            foreach (var key in keys.Select(kvp => kvp.Key))
            {
                var message = new Message
                {
                    SendingDate = DuplicatedMessages[key].message.SendingDate,
                    IsFromAdmin = DuplicatedMessages[key].message.IsFromAdmin,
                    UserId = DuplicatedMessages[key].message.RoomId,
                    Content = DuplicatedMessages[key].message.Content,
                    IsRead = DuplicatedMessages[key].message.IsReadByAdmin
                };

                dbContext.Set<Message>().Add(message);
                await dbContext.SaveChangesAsync();

                RemoveDuplicates(key);
            }
        }
    }
}