using ApplicationProcess.Web.Infrastructure.CustomExtensions;
using ApplicationProcess.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApplicationProcess.Web
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
            services.AddCustomCacheManagement()
                    .AddCustomSwagger()
                    .AddCustomCors()
                    .AddCustomFluentValidation()
                    .AddCustomMediatr()
                    .AddCustomRefitClients(Configuration)
                    .AddInfrastructureServices(Configuration)
                    //.AuthenticationService(Configuration) // ToDo to hired applicants
                    .AddControllers(options =>
                    {
                        options.Filters.Add(typeof(HttpGlobalExceptionFilter));
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplicationProcess.Web v1"));
            }

            app.UseCors("CorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
