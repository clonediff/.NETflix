using System.Text;
using System.Text.Json;
using Contracts.Shared;
using MassTransit;
using RabbitMQ.Client;
using static Configuration.Shared.Constants.QueueExchanges;

namespace Services.Shared.FilmVisitsService;

public class FilmVisitsService : IFilmVisitsService
{
    private readonly IBus _bus;
    private readonly IModel _channel;

    public FilmVisitsService(IBus bus, IModel channel)
    {
        _bus = bus;
        _channel = channel;
    }

    public async Task HandleFilmVisitAsync(int filmId)
    {
        await _bus.Publish(new PersistFilmVisitMessage(filmId));

        _channel.BasicPublish(
            exchange: FilmVisitsExchangeName,
            routingKey: filmId.ToString(),
            basicProperties: null,
            body: Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new FilmVisitMessage()))
        );
    }
}