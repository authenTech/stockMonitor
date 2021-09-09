using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

namespace MonitorHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("hostsettings.json", optional: true);
                    // configHost.AddEnvironmentVariables(prefix: "PREFIX_");
                    configHost.AddCommandLine(args);
                })
                
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<LifetimeEventsHostedService>();
                });
        }
    }
}
