using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<FieldType> Types { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<Timezone> Timezones { get; set; }
        public DbSet<Regex> Regexes { get; set; }
        public DbSet<EncodingType> EncodingTypes { get; set; }

        public DbSet<DateTimeFormat> DateTimeFormats { get; set; }

        public DbSet<CountryDataset> CountriesDataset { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }
    }
}
