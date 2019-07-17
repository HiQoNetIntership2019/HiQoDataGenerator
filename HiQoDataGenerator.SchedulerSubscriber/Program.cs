using HiQoDataGenerator.SchedulerSubscriber.Services;
using HiQoDataGenerator.SchedulerSubscriber.Extensions;
using HiQoDataGenerator.Infrastructure.DirectoryExtensions;
using HiQoDataGenerator.Infrastructure.LoggerExtensions;
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
                .SetBasePath(DirectoryExtensions.GetCurrentDirectory())
                .AddJsonFile("settings.json", optional: true, reloadOnChange: true);
            var configuration = builder.Build();

            var services = new ServiceCollection()
                .AddSubscriberServices(configuration)
                .BuildServiceProvider();

            LoggerExtensions.CreateLogger("Subscriber");
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
    }
}
