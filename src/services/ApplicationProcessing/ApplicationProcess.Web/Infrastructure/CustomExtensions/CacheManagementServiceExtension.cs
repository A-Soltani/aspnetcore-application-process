using ApplicationProcess.Infrastructure.CacheManagement;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
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