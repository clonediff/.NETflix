using Contracts.Shared;
using DotNetflix.Analytics.Repositories;
using MassTransit;

namespace DotNetflix.Analytics.Consumers;

public class PersistFilmVisitMessageConsumer : IConsumer<PersistFilmVisitMessage>
{
    private readonly IFilmVisitsRepository _filmVisitsRepository;

    public PersistFilmVisitMessageConsumer(IFilmVisitsRepository filmVisitsRepository)
    {
        _filmVisitsRepository = filmVisitsRepository;
    }

    public Task Consume(ConsumeContext<PersistFilmVisitMessage> context)
    {
        return _filmVisitsRepository.AddOrUpdateVisitAsync(context.Message.FilmId);
    }
}