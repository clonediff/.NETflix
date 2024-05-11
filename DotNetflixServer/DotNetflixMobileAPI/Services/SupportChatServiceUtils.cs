using System.Security.Claims;
using Contracts.Shared;
using Grpc.Core;

namespace DotNetflixMobileAPI.Services;

internal static class SupportChatServiceUtils
{    
    internal static string? GetUserId(ServerCallContext context)
    {
        return context
            .GetHttpContext()
            .User?
            .FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?
            .Value;
    }

    internal static string? GetUserName(ServerCallContext context)
    {
        return context.GetHttpContext()
            .User?
            .Identity?
            .Name;
    }

    internal static MessageType ToMessageType(SupportChatMessageType type)
    {
        return type switch
        {
            SupportChatMessageType.Text => MessageType.Text,
            SupportChatMessageType.File => MessageType.File,
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };
    }

    internal static SupportChatMessageType ToSupportChatMessageType(MessageType type)
    {
        return type switch
        {
            MessageType.Text => SupportChatMessageType.Text,
            MessageType.File => SupportChatMessageType.File,
            _ => throw new ArgumentOutOfRangeException(nameof(type))
        };

    }
}