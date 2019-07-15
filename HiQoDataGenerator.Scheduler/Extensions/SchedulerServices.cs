using Microsoft.Extensions.DependencyInjection;
using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.EventBus.Events;
using HiQoDataGenerator.Scheduler.Services;
using HiQoDataGenerator.Scheduler.Jobs;
using Quartz.Spi;
using Quartz;
using Quartz.Impl;
using Microsoft.Extensions.Configuration;

namespace HiQoDataGenerator.Scheduler.Extensions
{
    public static class SchedulerServices
    {
        public static IServiceCollection AddSchedulerServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton<SchedulerHostedService>();
            services.AddSingleton<IJobFactory, SchedulerJobsFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            
            services.AddScoped<PublishEventJob>();
            services.AddScoped<RabbitMqEventBus>(f => new RabbitMqEventBus(configuration["RabbitMqQueueName"]));
            services.AddScoped<TimerEvent>(f => new TimerEvent("DoWork"));
            services.AddSingleton(new JobSchedule(
                jobType: typeof(PublishEventJob),
                cronExpression: configuration.GetSection("PublishEventJob")?.GetSection("cronExpression")?.Value ?? "0 0/10 * 1/1 * ? *"));            
            return services;
        }
    }
}
