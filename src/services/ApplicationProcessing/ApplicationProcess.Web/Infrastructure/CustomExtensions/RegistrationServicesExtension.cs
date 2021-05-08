using ApplicationProcess.Domain.AggregatesModel.ApplicantAggregate;
using ApplicationProcess.Infrastructure.ExternalServices.RestCountries;
using ApplicationProcess.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicantContext>(options => options.UseInMemoryDatabase(databaseName: "test"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            services.AddTransient<IApplicantRepository, ApplicantRepository>();
            services.AddTransient<ICountryService, CountryService>();

            return services;
        }

        
    }

    public class Services
    {
    }
}