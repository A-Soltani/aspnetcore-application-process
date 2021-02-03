using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Hahn.ApplicationProcess.December2020.Web.Infrastructure.Serilog
{
    public static class SerilogConfiguration
    {
        private static readonly string Namespace = typeof(Startup).Namespace;
        private static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

        public static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        public static ILogger CreateLogger(IConfiguration configuration)
        {
            // ToDo Seq could be setup here
            //var seqServerUrl = configuration["Serilog:SeqServerUrl"];
            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithProperty("ApplicationContext", AppName)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

    }
}