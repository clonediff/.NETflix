using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

public record ChangeSubscriptionAvailabilityCommand(ChangeSubscriptionAvailabilityDto Dto) : ICommand;