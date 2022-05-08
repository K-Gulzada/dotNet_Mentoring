using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System.IO;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //  Log.Logger = new LoggerConfiguration().WriteTo.InMemory().CreateLogger();
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
                   .Enrich.FromLogContext()
                       .WriteTo.Console()
                           .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
