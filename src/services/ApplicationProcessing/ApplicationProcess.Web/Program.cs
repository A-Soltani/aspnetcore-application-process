using System;
using ApplicationProcess.Web.Infrastructure.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ApplicationProcess.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = SerilogConfiguration.GetConfiguration();
            Log.Logger = SerilogConfiguration.CreateLogger(configuration);

            try
            {
                Log.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureLogging(logging => 
                    logging.AddFilter("Microsoft", LogLevel.Information)
                           .AddFilter("System", LogLevel.Error)
                        )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
