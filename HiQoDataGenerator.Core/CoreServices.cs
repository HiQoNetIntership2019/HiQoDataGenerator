using AutoMapper;
using HiQoDataGenerator.Core.Extensions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace HiQoDataGenerator.Core
{
    public static class CoreServices
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.Scan(sc =>
                sc.FromCallingAssembly()
                    .AddClasses(classes => classes.InNamespaceOf<ConstraintsService>())
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }

        public static IMapper GetMapper() => MapperExtension.GetMapper();
    }
}
