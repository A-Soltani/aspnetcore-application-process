﻿using System.Threading;
using System.Threading.Tasks;
using Hahn.ApplicationProcess.December2020.Application.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Hahn.ApplicationProcess.December2020.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("----- Handling request {RequestName} ({@Request})", request.GetGenericTypeName(), request);
            var response = await next();
            _logger.LogInformation("----- Request {RequestName} handled - response: {@Response}", request.GetGenericTypeName(), response);

            return response;
        }
    }
}
