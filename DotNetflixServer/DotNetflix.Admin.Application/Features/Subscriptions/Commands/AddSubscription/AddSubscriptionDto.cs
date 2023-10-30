namespace DotNetflix.Admin.Application.Features.Subscriptions.Commands.AddSubscription;

public record AddSubscriptionDto(string Name, int Cost, int? PeriodInDays);