using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.DeleteSubscription;

public record DeleteSubscriptionCommand(int SubscriptionId) : ICommand;