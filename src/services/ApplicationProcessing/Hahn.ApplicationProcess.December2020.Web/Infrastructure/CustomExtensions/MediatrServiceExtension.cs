using Hahn.ApplicationProcess.December2020.Application.Behaviors;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions
{
    public static class MediatrServiceExtension
    {
        public static IServiceCollection AddCustomMediatr(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddApplicantCommandHandler));
                    
            return services;
        }
    }
}