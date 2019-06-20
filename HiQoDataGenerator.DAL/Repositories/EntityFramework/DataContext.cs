using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Configuration;
using System.IO;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<FieldType> Types { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<Timezone> Timezones { get; set; }

        private readonly string _connectionType = "Connection";
        private readonly string _connectionString;
        public DataContext() : base()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"))
                .Build();


            _connectionString = config.GetConnectionString(_connectionType);
         
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);
    }
}
