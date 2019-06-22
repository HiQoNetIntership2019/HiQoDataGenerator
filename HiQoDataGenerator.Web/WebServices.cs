using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

        public static IMapper GetMapper() => Extensions.MapperExtension.GetMapper();

        public static void InitializeMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetService<DataContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
