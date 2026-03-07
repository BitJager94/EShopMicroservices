using MediatR;
using System;
using System.Windows.Input;

namespace SharedBlocks.CQRS;
//Command with no response (unti is void in mediatR)
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{

}


public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse: notnull
   
{

}
