namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.UpdateSubscription;

public record UpdateSubscriptionDto(int Id, string Name, int Cost, int? PeriodInDays);