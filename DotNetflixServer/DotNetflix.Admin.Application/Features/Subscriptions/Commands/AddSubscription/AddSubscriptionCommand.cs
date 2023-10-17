using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.AddSubscription;

public record AddSubscriptionCommand(AddSubscriptionDto Dto) : ICommand;