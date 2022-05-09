using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Net;

namespace BrainstormSessions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Serilog.Debugging.SelfLog.Enable(Console.WriteLine);
            var emailInfo = new EmailConnectionInfo
            {
                EmailSubject = "Serilog Email Bug",
                EnableSsl = false,
                Port = 587,
                FromEmail = "from@gmail.com",
                MailServer = "smtp.gmail.com",
                ToEmail = "to@gmail.com",
                NetworkCredentials = new NetworkCredential("username", "pass")
            };

            using (var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Email(emailInfo, mailSubject: "Logs",
            restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger())
            {
                for (var i = 1; i <= 100; i++)
                {
                    logger.Information($"Log #{i}");
                }
            }

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
