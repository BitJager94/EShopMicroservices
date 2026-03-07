using MediatR;
using System;
using System.Windows.Input;

namespace SharedBlocks.CQRS;

public interface ICommand : ICommand<Unit>
{

}

public interface ICommand<out TResponse> : IRequest<TResponse>
{

}
