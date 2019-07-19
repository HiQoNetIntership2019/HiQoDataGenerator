using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.Interfaces;
using HiQoDataGenerator.Web.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Web
{
    public static class WebServices
    {
        public static void AddMapperFactory(this IServiceCollection services)
        {
            var factory = new MapperFactory();

            factory.Mappers.Add(typeof(CoreServices).Name, CoreServices.GetMapper());
            factory.Mappers.Add(typeof(WebServices).Name, WebServices.GetMapper());

            services.AddSingleton<IMapperFactory>(factory);
        }

        public static void AddBackgroundTasksQueue(this IServiceCollection services)
        {
            services.AddHostedService<QueuedDataSavingService>();
            services.AddSingleton<IBackgroundDataSavingTasksQueue, BackgroundDataSavingTasksQueue>();
        }

        public static IMapper GetMapper() => Extensions.MapperExtension.GetMapper();
    }
}
