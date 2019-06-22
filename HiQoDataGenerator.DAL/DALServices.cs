using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Contracts.Repositories.Datasets;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using HiQoDataGenerator.DAL.Repositories.EntityFramework.Datasets;
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
            services.AddScoped<IFieldTypeRepository, FieldTypesRepository>();
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<ICountriesDatasetRepository, CountriesDatasetRepository>();
        }
    }
}
