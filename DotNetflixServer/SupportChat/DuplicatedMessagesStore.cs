using System.Collections.Concurrent;
using Contracts.Shared;

namespace SupportChat;

public static class DuplicatedMessagesStore
{
    public static ConcurrentDictionary<string, (int count, SupportChatMessage message)> DuplicatedMessages { get; } = [];

    public static void RemoveDuplicates(string key) => DuplicatedMessages.TryRemove(key ?? "", out var _);
}