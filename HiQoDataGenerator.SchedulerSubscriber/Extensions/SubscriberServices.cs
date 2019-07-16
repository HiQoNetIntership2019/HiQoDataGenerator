using Microsoft.Extensions.DependencyInjection;
using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.SchedulerSubscriber.Services;
using Microsoft.Extensions.Configuration;
using HiQoDataGenerator.SchedulerSubscriber.Handlers;
using HiQoDataGenerator.DAL;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.Core.Interfaces;

namespace HiQoDataGenerator.SchedulerSubscriber.Extensions
{
    public static class SubscriberServices
    {
        public static IServiceCollection AddSubscriberServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<SubscriberHostedService>();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<RabbitMqEventBus>(f => new RabbitMqEventBus("RecieveEvent"));
            services.AddScoped<TimerEventHandler>();
            
            services.AddDALServices(configuration.GetConnectionString("PostgreConnection"));
            services.AddMapperFactory();
            services.AddBLServices();
            return services;
        }

        public static void AddMapperFactory(this IServiceCollection services)
        {
            var factory = new MapperFactory();
            factory.Mappers.Add(typeof(CoreServices).Name, CoreServices.GetMapper());
            services.AddSingleton<IMapperFactory>(factory);
        }
    }
}
