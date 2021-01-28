using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions
{
    public static class FluentValidationServiceExtension
    {
        public static IServiceCollection AddCustomFluentValidation(this IServiceCollection services)
        {
            var assemblies = new[]
            {
                typeof(AddApplicantCommand).Assembly
            };

            services.AddMvc().AddFluentValidation(c =>
            {
                c.RegisterValidatorsFromAssemblies(assemblies);
                c.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            return services;
        }
    }
}