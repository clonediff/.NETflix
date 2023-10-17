using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateFilmsInSubscription;

public record UpdateFilmsInSubscriptionCommand(int SubscriptionId, IDictionary<int, bool> Movies) : ICommand;