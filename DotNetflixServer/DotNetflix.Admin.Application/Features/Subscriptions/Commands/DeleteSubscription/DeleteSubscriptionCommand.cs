using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.DeleteSubscription;

public record DeleteSubscriptionCommand(int SubscriptionId) : ICommand<Result<int, string>>;