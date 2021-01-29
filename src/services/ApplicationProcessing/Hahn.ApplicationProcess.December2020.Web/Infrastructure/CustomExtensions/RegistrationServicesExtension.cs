using System;
using System.Collections.Generic;
using System.Reflection;
using FluentValidation.AspNetCore;
using Hahn.ApplicationProcess.December2020.Domain.AggregatesModel.ApplicantAggregate;
using Hahn.ApplicationProcess.December2020.Infrastructure.ExternalServices.RestCountries;
using Hahn.ApplicationProcess.December2020.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions
{
    public static class RegistrationServicesExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicantContext>(options => options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            services.AddTransient<IApplicantRepository, ApplicantRepository>();
            services.AddTransient<ICountryService, CountryService>();

            return services;
        }

        
    }

    public class Services
    {
    }
}