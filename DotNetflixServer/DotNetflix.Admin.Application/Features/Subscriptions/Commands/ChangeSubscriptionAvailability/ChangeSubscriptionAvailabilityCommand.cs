using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

public record ChangeSubscriptionAvailabilityCommand(int Id, bool IsAvailable) : ICommand<Result<int, string>>;