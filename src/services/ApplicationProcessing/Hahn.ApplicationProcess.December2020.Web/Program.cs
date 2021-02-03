using Hahn.ApplicationProcess.December2020.Web.Infrastructure.Serilog;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Hahn.ApplicationProcess.December2020.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = SerilogConfiguration.GetConfiguration();
            Log.Logger = SerilogConfiguration.CreateLogger(configuration);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
