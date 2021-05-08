using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ApplicationProcess.Web.Infrastructure.CustomExtensions
{
    public static class SwaggerServiceExtension
    {
		public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ApplicationProcess API",
                    Version = "v1",
                    Description = "The Application Process Service API",
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new string[] { }
                    }
                });
                c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\ApplicationProcess.Application.XML");

            });

            return services;
        }
	}
}