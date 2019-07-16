using System;
using HiQoDataGenerator.SchedulerSubscriber.Services;
using HiQoDataGenerator.SchedulerSubscriber.Extensions;
using Serilog;
using System.IO;
using Topshelf;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace HiQoDataGenerator.SchedulerSubscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            var services = new ServiceCollection()
                .AddSubscriberServices(configuration)
                .BuildServiceProvider();

            ConfigureLogger();
            HostFactory.Run(config =>
            {
                config.Service<SubscriberHostedService>(s =>
                {
                    s.ConstructUsing(service => services.GetService<SubscriberHostedService>());
                    s.WhenStarted(service => service.StartAsync());
                    s.WhenStopped(service => service.StopAsync());
                });

                config.RunAsLocalSystem();
                config.StartAutomatically();

                config.SetDescription("Subscriber (Topshelf Service)");
                config.SetDisplayName("HiQoSchedulerSubscriber");
                config.SetServiceName("HiQoSchedulerSubscriber");
            });
        }

        private static void ConfigureLogger()
        {
            var fileName = $"Subscriber_{DateTime.Now.ToString("ddMMyyyy")}.log";
            var filePath = Path.Combine(AppContext.BaseDirectory, "Logs", fileName);

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(filePath)
               .CreateLogger();
        }
    }
}
