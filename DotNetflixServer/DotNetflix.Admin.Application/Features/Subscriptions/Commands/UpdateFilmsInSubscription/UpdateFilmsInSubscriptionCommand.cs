using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateFilmsInSubscription;

public record UpdateFilmsInSubscriptionCommand(int SubscriptionId, IDictionary<int, bool> Movies) : ICommand<Result<int, string>>;