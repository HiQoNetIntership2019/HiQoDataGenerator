using HiQoDataGenerator.GeneratorCore.Generators;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.GeneratorCore
{
    public static class GeneratorCoreServices
    {
        public static void AddGeneratorCoreSerives(this IServiceCollection services)
        {
            
            var fieldsGenerator = new FieldsGenerator(
                new IntegerGenerator(),
                new DoubleGenerator(),
                new DecimalGenerator(),
                new ComplexGenerator(),
                new BoolGenerator(),
                new StringGenerator(),
                new DateTimeGenerator(),
                new DateGenerator()
                );

            services.AddSingleton<IFieldsGenerator>(fieldsGenerator);
            services.AddSingleton<IDataGeneratorService, DataGeneratorService>();
        }
    }
}
