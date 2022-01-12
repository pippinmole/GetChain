using System;
using GetChain.GetChain.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace GetChain {
    public class Program {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(ConfigureSerilog, true)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
        
        private static void ConfigureSerilog(HostBuilderContext context, LoggerConfiguration config) {
            config.ReadFrom.Configuration(context.Configuration);
            var ddOptions = context.Configuration.GetSection("Serilog")?.GetSection("DataDog")
                ?.Get<DatadogOptions>();

            if ( ddOptions != null ) {
                config.WriteTo.DatadogLogs(
                    apiKey: ddOptions.ApiKey,
                    source: ".NET",
                    service: ddOptions.ServiceName ?? "GetChain",
                    host: ddOptions.HostName ?? Environment.MachineName,
                    tags: new[] {
                        $"env:{ddOptions.EnvironmentName ?? context.HostingEnvironment.EnvironmentName}",
                        $"assembly:{ddOptions.AssemblyName ?? context.HostingEnvironment.ApplicationName}"
                    },
                    configuration: ddOptions.ToDatadogConfiguration(),
                    logLevel: ddOptions.OverrideLogLevel ?? LogEventLevel.Verbose
                );
            }
        }
    }
}