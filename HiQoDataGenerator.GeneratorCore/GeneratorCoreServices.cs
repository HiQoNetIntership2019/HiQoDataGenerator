using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models;
using HiQoDataGenerator.GeneratorCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.GeneratorCore
{
    public static class GeneratorCoreServices
    {
        public static void AddGeneratorCoreSerives(this IServiceCollection services)
        {
            services.AddSingleton<IFieldsGenerator, FieldsGenerator>();
            services.AddSingleton<IDataGeneratorService, DataGeneratorService>();
        }
    }
}
