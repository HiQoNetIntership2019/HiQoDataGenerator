using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Scrutor;

namespace HiQoDataGenerator.DAL
{
    public static class DALServices
    {
        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.Scan(sc =>
                sc.FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)), publicOnly: true)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());
        }
    }
}
