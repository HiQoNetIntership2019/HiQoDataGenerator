using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Web.Extensions
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


        public static IMapper GetMapper() => MapperExtension.GetMapper();
    }
}
