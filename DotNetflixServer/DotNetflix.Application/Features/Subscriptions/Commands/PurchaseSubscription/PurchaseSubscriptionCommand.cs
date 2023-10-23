using Contracts.Shared;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.Subscriptions.Shared;

namespace DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;

public record PurchaseSubscriptionCommand(UserSubscriptionDto UserSubscriptionDto, CardDataDto CardDataDto) : ICommand<Result<int, string>>;
