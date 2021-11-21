using ApplicationProcess.Application.Behaviors;
using ApplicationProcess.Application.Commands.AddApplicant;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
{
    public static class MediatrServiceExtension
    {
        public static IServiceCollection AddCustomMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddApplicantCommandHandler));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

          

            return services;
        }
    }
}