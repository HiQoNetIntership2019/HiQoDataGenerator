using HiQoDataGenerator.GeneratorCore.Generators;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HiQoDataGenerator.GeneratorCore
{
    public static class GeneratorCoreServices
    {
        public static void AddGeneratorCoreServices(this IServiceCollection services)
        {
            IRandomValuesGenerator randomValuesGenerator = new RandomValuesGenerator();

            IFieldsGenerator fieldsGenerator = new FieldsGenerator(
                new DatasetValueGenerator(),
                new ByteGenerator(randomValuesGenerator),
                new IntegerGenerator(randomValuesGenerator),
                new DoubleGenerator(randomValuesGenerator),
                new DecimalGenerator(randomValuesGenerator),
                new ComplexGenerator(randomValuesGenerator),
                new BoolGenerator(randomValuesGenerator),
                new StringGenerator(randomValuesGenerator),
                new DateTimeGenerator(randomValuesGenerator),
                new DateGenerator(randomValuesGenerator),
                new GuidGenerator(randomValuesGenerator)
            );

            services.AddSingleton(fieldsGenerator);
            services.AddSingleton<IDataGeneratorService, DataGeneratorService>();
        }
    }
}
