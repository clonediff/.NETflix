using System.Collections.Concurrent;

namespace DotNetflixAPI.Hubs;

public static class ConnectionStore
{
    public static readonly ConcurrentDictionary<string, List<string>> UserConnections = new();
}