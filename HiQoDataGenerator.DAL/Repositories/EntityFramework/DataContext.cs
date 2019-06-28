using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using Microsoft.Extensions.Configuration;
using System.IO;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DataContext : DbContext
    {
        public DbSet<FieldType> Types { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<ConstraintValue> ConstraintValues { get; set; }
        public DbSet<Timezone> Timezones { get; set; }
        public DbSet<Regex> Regexes { get; set; }
        public DbSet<EncodingType> EncodingTypes { get; set; }
        public DbSet<DateTimeFormat> DateTimeFormats { get; set; }
        public DbSet<CustomDataset> CustomDatasets { get; set; }
        public DbSet<CustomDatasetValue> CustomDatasetsValues { get; set; }
        //public DbSet<DatasetType> DatasetTypes { get; set; }
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FieldTypeConstraint>()
               .HasOne(p => p.FieldType)
               .WithMany(p => p.SupportedConstraints)
               .HasForeignKey(p => p.FieldTypeId);

            builder.Entity<FieldTypeConstraint>()
                .HasOne(p => p.Constraint)
                .WithMany(p => p.SupportedTypes)
                .HasForeignKey(p => p.ConstraintId);
        }
    }
}
