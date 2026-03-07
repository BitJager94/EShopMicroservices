using MediatR;
using System;
using System.Windows.Input;


namespace SharedBlocks.CQRS;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse: notnull
   
{

}
