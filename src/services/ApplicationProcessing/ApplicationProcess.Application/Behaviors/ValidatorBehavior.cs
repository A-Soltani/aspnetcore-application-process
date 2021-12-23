using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApplicationProcess.Application.Extensions;
using ApplicationProcess.Domain.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ApplicationProcess.Application.Behaviors
{
    public sealed class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        //private readonly ILogger<ValidatorBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var typeName = request.GetGenericTypeName();


            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {

                throw new ApplicationProcessDomainException(
                    $"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException("Validation exception", failures));
            }


            //if (_validators.Any())
            //{
            //    var context = new ValidationContext<TRequest>(request);
            //    var validationResults =
            //        await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            //    var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
            //    if (failures.Count != 0)
            //        throw new FluentValidation.ValidationException(failures);

            //}

            return await next();

        }
    }
}