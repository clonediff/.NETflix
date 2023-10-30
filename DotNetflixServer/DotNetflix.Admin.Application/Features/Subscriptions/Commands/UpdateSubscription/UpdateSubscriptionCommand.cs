using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;

public record UpdateSubscriptionCommand(int Id, string Name, int Cost, int? PeriodInDays) : ICommand;