using MediatR;

namespace DotNetflix.Abstractions.Cqrs;

public interface ICommand : IRequest { }

public interface ICommand<out TResponse> : IRequest<TResponse> { }