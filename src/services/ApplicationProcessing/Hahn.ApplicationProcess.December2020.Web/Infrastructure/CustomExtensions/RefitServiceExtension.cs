using System;
using Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions
{
    public static class RefitServiceExtension
    {
        public static IServiceCollection AddCustomRefitClients(this IServiceCollection services, IConfiguration configuration)
        {
            var restCountriesUrl = configuration.GetSection("RestCountriesUrl")?.Value;
            services.AddRefitClient<ICountryClient>(restCountriesUrl);

            return services;
        }

        private static void AddRefitClient<T>(this IServiceCollection services, string url, int timeOut = 2) where T : class
        {
            services.AddRefitClient<T>()
                .ConfigureHttpClient(c => { c.BaseAddress = new Uri(url); })
                .SetHandlerLifetime(TimeSpan.FromMinutes(timeOut));
        }
    }
}