using MediatR;
using System;
using System.Windows.Input;


namespace SharedBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse: notnull
{

}
