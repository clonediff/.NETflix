namespace Configuration.Shared.RabbitMq;

public class RabbitMqConfig
{
    public const string SectionName = "RabbitMqConfig";
    
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Hostname { get; set; } = default!;
    public int Port { get; set; }
    
    public string FullHostname => $"amqp://{Username}:{Password}@{Hostname}:{Port}";
}
