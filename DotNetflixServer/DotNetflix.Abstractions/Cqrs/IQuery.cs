using MediatR;

namespace DotNetflix.Abstractions.Cqrs;

public interface IQuery<out TResponse> : IRequest<TResponse> { }