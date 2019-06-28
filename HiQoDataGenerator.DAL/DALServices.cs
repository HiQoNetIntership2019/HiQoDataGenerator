using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL
{
    public static class DALServices
    {
        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<ITimezoneRepository, TimezonesRepository>();

            services.AddScoped<IEncodingTypeRepository, EncodingTypesRepository>();

            services.AddScoped<IFieldTypeRepository, FieldTypesRepository>();

            services.AddScoped<IRegexRepository, RegexRepository>();    

            services.AddScoped<IConstraintsRepository, ConstraintsRepository>();

            services.AddScoped<IDateTimeFormatRepository, DateTimeFormatsRepository>();

            services.AddScoped<IDatasetTypesRepository, DatasetTypesRepository>();

            services.AddScoped<ICustomDatasetRepository, CustomDatasetsRepository>();

            services.AddScoped<IConstraintValuesRepository, ConstraintValuesRepository>();

            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IConfigurableObjectsRepository, ConfigurableObjectsRepository>();

            services.AddScoped<IFieldTypesConstraintsRepository, FieldTypesConstraintsRepository>();
        }
    }
}
