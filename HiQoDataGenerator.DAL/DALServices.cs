using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HiQoDataGenerator.DAL.Repositories.MongoDirver;
using HiQoDataGenerator.DAL.Repositories.MongoDriver;

namespace HiQoDataGenerator.DAL
{
    public static class DALServices
    {
        public static void AddDALServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseNpgsql(connectionString));

            services.Scan(sc =>
                sc.FromCallingAssembly()
                    .AddClasses(classes => classes.AssignableTo(typeof(IGenericRepository<>)), publicOnly: true)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

            services.AddScoped<IFilesGeneratedObjectsRepository, FilesGeneratedObjectsRepository>();
            services.AddScoped<IGeneratedObjectsRepository, GeneratedObjectsRepository>();
        }
    }
}
