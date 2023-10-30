using MediatR;

namespace DotNetflix.CQRS.Abstractions;

public interface ICommand : IRequest { }

public interface ICommand<out TResponse> : IRequest<TResponse> { }