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
            services.AddScoped<IConstraintsRepository, ConstraintsRepository>();

            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
