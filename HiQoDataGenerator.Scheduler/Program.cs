using System;
using HiQoDataGenerator.Scheduler.Services;
using Serilog;
using System.IO;
using Topshelf;

namespace HiQoDataGenerator.Scheduler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConfigureLogger();
            HostFactory.Run(config =>
            {
                config.Service<SchedulerHostedService>(s =>
                {
                    s.ConstructUsing(service => new SchedulerHostedService());
                    s.WhenStarted(service => service.StartAsync());
                    s.WhenStopped(service => service.StopAsync());
                });

                config.RunAsLocalSystem();
                config.StartAutomatically();

                config.SetDescription("Scheduler (Topshelf Service)");
                config.SetDisplayName("HiQoScheduler");
                config.SetServiceName("HiQoScheduler");
            });
        }

        private static void ConfigureLogger()
        {
            var fileName = $"Scheduler_{DateTime.Now.ToString("ddMMyyyy")}.log";
            var filePath = Path.Combine(AppContext.BaseDirectory,"Logs",fileName);

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(filePath)
               .CreateLogger();
        }
    }
}
