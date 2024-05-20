using DotNetflix.Analytics.Repositories;
using RabbitMQ.Client;
using static Configuration.Shared.Constants.QueueExchanges;

namespace DotNetflix.Analytics.GraphQL;

public class Queries
{
    private readonly IFilmVisitsRepository _filmVisitsRepository;
    private readonly IModel _channel;

    public Queries(IFilmVisitsRepository filmVisitRepository, IModel channel)
    {
        _filmVisitsRepository = filmVisitRepository;
        _channel = channel;
    }

    public Task<int> GetFilmVisits(int filmId)
    {
        return _filmVisitsRepository.GetFilmVisitsAsync(filmId);
    }

    public string Connect(int filmId)
    {
        var queueName = _channel.QueueDeclare(Guid.NewGuid().ToString(), false, false, true).QueueName;
        _channel.QueueBind(queueName, FilmVisitsExchangeName, filmId.ToString());

        return queueName;
    }
}