using Hahn.ApplicationProcess.December2020.Infrastructure.CacheManagement;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions
{
    public static class CacheManagementServiceExtension
    {
        public static IServiceCollection AddCustomCacheManagement(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheProvider, CacheProvider>();

            return services;
        }
    }
}