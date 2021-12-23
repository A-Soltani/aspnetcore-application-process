using ApplicationProcess.Application.Commands.AddApplicant;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
{
    public static class FluentValidationServiceExtension
    {
        public static IServiceCollection AddCustomFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(AddApplicantCommandValidator));

            return services;
        }
    }
}