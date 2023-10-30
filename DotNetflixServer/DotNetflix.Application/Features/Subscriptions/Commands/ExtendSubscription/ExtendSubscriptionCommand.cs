using Contracts.Shared;
using DotNetflix.Application.Features.Subscriptions.Shared;
using DotNetflix.CQRS;
using DotNetflix.CQRS.Abstractions;
using DotNetflix.CQRS.BehaviorMarkers;

namespace DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;

public record ExtendSubscriptionCommand(UserSubscriptionDto UserSubscriptionDto, CardDataDto CardDataDto) : ICommand<Result<int, string>>, IHasCardValidation;
