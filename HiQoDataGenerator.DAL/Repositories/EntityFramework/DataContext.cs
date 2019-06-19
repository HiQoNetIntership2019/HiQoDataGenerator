using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class DataContext : DbContext
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=hiqodatagen;Username=postgres;Password=password";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_connectionString);
    }
}
