using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Application.Behaviors
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidatorBehavior(IValidator<TRequest>[] validators) => 
            _validators = validators ?? throw new ArgumentNullException(nameof(validators));

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Get FluentValidation errors 
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            // Check for having errors
            if (failures.Any())
            {
                throw new Exception(
                    $"Command Validation Errors for type {typeof(TRequest).Name}",
                    new ValidationException("Validation exception", failures));
            }

            return await next();
        }
    }
}
