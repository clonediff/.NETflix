using Contracts.Shared;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using DotNetflix.Application.Features.Subscriptions.Shared;

namespace DotNetflix.Application.Features.Subscriptions.Commands.ExtendSubscription;

public record ExtendSubscriptionCommand(UserSubscriptionDto UserSubscriptionDto, CardDataDto CardDataDto) : ICommand<Result<int, string>>;
