using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.ChangeSubscriptionAvailability;

public record ChangeSubscriptionAvailabilityCommand(int Id, bool IsAvailable) : ICommand<Result<int, string>>;