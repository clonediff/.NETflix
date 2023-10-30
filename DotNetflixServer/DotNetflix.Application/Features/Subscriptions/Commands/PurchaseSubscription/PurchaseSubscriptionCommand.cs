using Contracts.Shared;
using DotNetflix.Application.Features.Subscriptions.Shared;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Application.Features.Subscriptions.Commands.PurchaseSubscription;

public record PurchaseSubscriptionCommand(UserSubscriptionDto UserSubscriptionDto, CardDataDto CardDataDto) : ICommand<Result<int, string>>, IHasCardValidation;
