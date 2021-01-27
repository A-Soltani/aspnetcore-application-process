using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Hahn.ApplicationProcess.December2020.Application.Commands.AddApplicant;
using Hahn.ApplicationProcess.December2020.Web.Infrastructure.CustomExtensions;
using MediatR;

namespace Hahn.ApplicationProcess.December2020.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddValidatorsFromAssemblyContaining(typeof(AddApplicantCommandValidator));
            //services.AddTransient<IValidator<AddApplicantCommand>, AddApplicantCommandValidator>();
            services.AddFluentValidation(new[]
            {
                typeof(AddApplicantCommand).Assembly
            });
            services.AddCustomSwagger()
                .AddCustomCors()
                .AddCustomMediatr()
                .AddInfrastructureServices(Configuration)
                //.AuthenticationService(Configuration)
                .AddControllers();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hahn.ApplicationProcess.December2020.Web v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
