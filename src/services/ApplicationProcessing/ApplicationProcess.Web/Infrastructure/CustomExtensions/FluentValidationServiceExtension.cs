using ApplicationProcess.Application.Commands.AddApplicant;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
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