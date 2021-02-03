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
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            
            return configuration;
        }

        public static ILogger CreateLogger(IConfiguration configuration)
        {
            // ToDo Seq could be setup here
            //var seqServerUrl = configuration["Serilog:SeqServerUrl"];
            return new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

    }
}