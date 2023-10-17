using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;

public record UpdateSubscriptionCommand(UpdateSubscriptionDto Dto) : ICommand;