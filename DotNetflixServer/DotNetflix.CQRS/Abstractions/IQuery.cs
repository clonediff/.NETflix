using MediatR;

namespace DotNetflix.CQRS.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse> { }