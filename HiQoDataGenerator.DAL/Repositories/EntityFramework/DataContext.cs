using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<FieldType> Types { get; set; }

        private readonly string _connectionString = "Host=localhost;Port=5432;Database=DataGeneratorDatabase;Username=postgres;Password=denis123";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);
    }
}
