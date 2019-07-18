using HiQoDataGenerator.Scheduler.Services;
using HiQoDataGenerator.Scheduler.Extensions;
using HiQoDataGenerator.Infrastructure.DirectoryExtensions;
using HiQoDataGenerator.Infrastructure.LoggerExtensions;
using Topshelf;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace HiQoDataGenerator.Scheduler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(DirectoryExtensions.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            var services = new ServiceCollection()                
                .AddSchedulerServices(configuration)
                .BuildServiceProvider();

            LoggerExtensions.CreateLogger("Scheduler");
            HostFactory.Run(config =>
            {
                config.Service<SchedulerHostedService>(s =>
                {
                    s.ConstructUsing(service => services.GetService<SchedulerHostedService>());
                    s.WhenStarted(async service => await service.StartAsync(CancellationToken.None));
                    s.WhenStopped(async service => await service.StopAsync(CancellationToken.None));
                });

                config.RunAsLocalSystem();
                config.StartAutomatically();

                config.SetDescription("Scheduler (Topshelf Service)");
                config.SetDisplayName("HiQoScheduler");
                config.SetServiceName("HiQoScheduler");
            });
        }
    }
}
