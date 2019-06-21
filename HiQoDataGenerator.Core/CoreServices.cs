using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.Core
{
    public static class CoreServices
    {
        public static void AddBLServices(this IServiceCollection services)
        {
            services.AddScoped<ITimezonesService, TimezoneService>();
            services.AddScoped<IConstraintsService, ConstraintsService>();
        }
    }
}
