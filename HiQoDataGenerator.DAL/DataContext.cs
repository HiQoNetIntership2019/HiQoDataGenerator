using HiQoDataGenerator.DAL.Extensions;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL
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
        public DbSet<Field> Fields { get; set; }
        public DbSet<DatasetType> DatasetTypes { get; set; }
        public DbSet<DefinedDataset> DefinedDatasets { get; set; }
        public DbSet<DefinedDatasetValue> DefinedDatasetsValues { get; set; }
        public DbSet<Dataset> Datasets { get; set; }
        public DbSet<FileMetadata> FilesMetadata{ get;set; }
        public DbSet<FileStatus> FileStatuses { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FieldTypeConstraint>().ToTable("Types_Support_Constraints");
            builder.Entity<FieldType>().ToTable("Types");

            #region Properties settings

            builder.Entity<Constraint>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Constraint>()
                .Property(p => p.Description)
                .HasColumnType("TEXT");

            builder.Entity<ConstraintValue>()
                .Property(p => p.Value)
                .HasMaxLength(300)
                .IsRequired();

            builder.Entity<DateTimeFormat>()
                .Property(p => p.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<EncodingType>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Regex>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Regex>()
                .Property(p => p.Value)
                .HasMaxLength(300)
                .IsRequired();

            builder.Entity<Timezone>()
                .Property(p => p.Value)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<Field>()
                .Property(p => p.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Entity<FieldType>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<CustomDataset>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<CustomDatasetValue>()
                .Property(p => p.Value)
                .HasMaxLength(150)
                .IsRequired();

            builder.Entity<DefinedDataset>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<DefinedDatasetValue>()
                .Property(p => p.Value)
                .HasMaxLength(150)
                .IsRequired();

            builder.Entity<Dataset>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<DatasetType>()
                .Property(p => p.TypeName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<ConfigurableObject>()
                .Property(p => p.DateCreation)
                .IsRequired();

            builder.Entity<FileMetadata>()
                .Property(p => p.Path)
                .HasMaxLength(150)
                .IsRequired();

            builder.Entity<FileStatus>()
                .Property(p => p.Status)
                .HasMaxLength(20)
                .IsRequired();
            #endregion

            #region Many-To-Many FieldType-Constraints

            builder.Entity<FieldTypeConstraint>()
                .HasOne(ftc => ftc.FieldType)
                .WithMany(ft => ft.SupportedConstraints)
                .HasForeignKey(ftc => ftc.FieldTypeId);

            builder.Entity<FieldTypeConstraint>()
                .HasOne(ftc => ftc.Constraint)
                .WithMany(c => c.SupportedTypes)
                .HasForeignKey(ftc => ftc.ConstraintId);

            #endregion

            builder.Seed();
        }
    }
}
