using AutoMapper;
using HiQoDataGenerator.Core.Extensions;
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
            services.AddScoped<IRegexService, RegexService>();
            services.AddScoped<IEncodingTypesService, EncodingTypeService>();
            services.AddScoped<IRegexService, RegexService>();
            services.AddScoped<IFieldTypeService, FieldTypeService>();
            services.AddScoped<IConstraintsService, ConstraintsService>();

        }

        public static IMapper GetMapper() => MapperExtension.GetMapper();
    }
}
