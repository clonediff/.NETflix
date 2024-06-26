﻿using DotNetflix.CQRS.Abstractions;

namespace DotNetflix.Application.Features.Users.Queries.GetAllUserSubscriptions;

public record GetAllUserSubscriptionsQuery(string UserId) : IQuery<IEnumerable<GetUserSubscriptionDto>>;
