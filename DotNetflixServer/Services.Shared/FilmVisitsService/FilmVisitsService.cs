using System.Text;
using System.Text.Json;
using Contracts.Shared;
using MassTransit;
using RabbitMQ.Client;

namespace Services.Shared.FilmVisitsService;

public class FilmVisitsService : IFilmVisitsService
{
    public const string ExchangeName = "film-visits";

    private readonly IBus _bus;
    private readonly IModel _channel;

    public FilmVisitsService(IBus bus, IModel channel)
    {
        _bus = bus;
        _channel = channel;
    }

    public async Task<string> HandleFilmVisitAsync(int filmId, bool declareQueue)
    {
        await _bus.Publish(new PersistFilmVisitMessage(filmId));

        var queueName = "";

        if (declareQueue)
        {
            queueName = _channel.QueueDeclare(exclusive: false).QueueName;
            _channel.QueueBind(queueName, ExchangeName, filmId.ToString());
        }

        _channel.BasicPublish(
            exchange: ExchangeName,
            routingKey: filmId.ToString(),
            basicProperties: null,
            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new FilmVisitMessage()))
        );

        return queueName;
    }
}