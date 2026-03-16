

using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedBlocks.CQRS;
using System.Diagnostics;


namespace SharedBlocks.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse>(ILogger<LoggingBehaviour<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull, IRequest<TResponse>
        where TResponse : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation("Handle request {Request} - Response {Response}", typeof(TRequest).Name, typeof(TResponse).Name);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();
            if (timer.Elapsed.Seconds > 3)
            {
                logger.LogWarning("Handle request {Request} - Response {Response} is taking considerable amount of time ({time} seconds)", typeof(TRequest).Name, typeof(TResponse).Name, timer.Elapsed.Seconds);
            }


            return response;
        }
    }
}
