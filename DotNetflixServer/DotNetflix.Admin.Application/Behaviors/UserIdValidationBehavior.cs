using DataAccess;
using DotNetflix.Abstractions;
using DotNetflix.Abstractions.Cqrs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotNetflix.Admin.Application.Behaviors;

public class UserIdValidationBehavior<TRequest, TSuccess> : IPipelineBehavior<TRequest, Result<TSuccess, string>>
    where TRequest : IHasUserIdValidation
{
    private readonly ApplicationDBContext _dbContext;

    public UserIdValidationBehavior(ApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Result<TSuccess, string>> Handle(
        TRequest request,
        RequestHandlerDelegate<Result<TSuccess, string>> next,
        CancellationToken cancellationToken)
    {
        var existUserWithThisId = await _dbContext.Users.AsNoTracking()
            .AnyAsync(x => x.Id == request.UserId, cancellationToken);
        
        if (!existUserWithThisId)
            return "Не удалось найти пользователя";
        
        return await next();
    }
}