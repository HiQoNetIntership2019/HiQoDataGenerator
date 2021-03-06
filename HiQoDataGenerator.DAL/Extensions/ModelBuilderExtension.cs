﻿using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FieldType>()
                .HasData(
                    new FieldType() { Id = 1, Name = "Byte" },
                    new FieldType() { Id = 2, Name = "Int" },
                    new FieldType() { Id = 3, Name = "Double" },
                    new FieldType() { Id = 4, Name = "Decimal" },
                    new FieldType() { Id = 5, Name = "Complex" },
                    new FieldType() { Id = 6, Name = "String" },
                    new FieldType() { Id = 7, Name = "Bool" },
                    new FieldType() { Id = 8, Name = "Date" },
                    new FieldType() { Id = 9, Name = "Time" },
                    new FieldType() { Id = 10, Name = "DateTime" },
                    new FieldType() { Id = 11, Name = "Enum" },
                    new FieldType() { Id = 12, Name = "Guid" }
                );

            modelBuilder.Entity<Constraint>()
                .HasData(
                    new Constraint() { Id = 1, Name = "min value", Description = "Minimal value for a numeric field." },
                    new Constraint() { Id = 2, Name = "max value", Description = "Maximal value for a numeric field." },
                    new Constraint() { Id = 4, Name = "max digits", Description = "Can be applied to a decimal field." },
                    new Constraint() { Id = 5, Name = "decimal place", Description = "Separator position for a decimal field." },
                    new Constraint() { Id = 6, Name = "max a value", Description = "Maximal re part value for a complex field." },
                    new Constraint() { Id = 7, Name = "min a value", Description = "Minimal re part value for a complex field." },
                    new Constraint() { Id = 8, Name = "max b value", Description = "Maximal img part value for a complex field." },
                    new Constraint() { Id = 9, Name = "min b value", Description = "Minimal img part value for a complex field." },
                    new Constraint() { Id = 11, Name = "regex", Description = "Custom or defined regexp applied to a field." },
                    new Constraint() { Id = 12, Name = "encoding", Description = "Encoding type for a string field." },

                    new Constraint() { Id = 13, Name = "start date", Description = "The left boundary for date [time] field." },
                    new Constraint() { Id = 14, Name = "end date", Description = "The right boundary for date [time] field." },
                    new Constraint() { Id = 15, Name = "timezone", Description = "Timezone applied to date [time] field." },
                    new Constraint() { Id = 16, Name = "format", Description = "Representation format for a date [time] field." },
                    new Constraint() { Id = 17, Name = "min length", Description = "Minimal length of a string field." },
                    new Constraint() { Id = 18, Name = "max length", Description = "Maximal length of a string field." }
                );

            modelBuilder.Entity<FieldTypeConstraint>()
                .HasData(
                    #region Constraints for byte
                    new FieldTypeConstraint() { Id = 1, FieldTypeId = 1, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 2, FieldTypeId = 1, ConstraintId = 2 },
                    #endregion

                    #region Constraints for int
                    new FieldTypeConstraint() { Id = 3, FieldTypeId = 2, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 4, FieldTypeId = 2, ConstraintId = 2 },
                    #endregion

                    #region Constraints for double
                    new FieldTypeConstraint() { Id = 5, FieldTypeId = 3, ConstraintId = 1 },
                    new FieldTypeConstraint() { Id = 6, FieldTypeId = 3, ConstraintId = 2 },
                    #endregion

                    #region Constraints for decimal
                    new FieldTypeConstraint() { Id = 9, FieldTypeId = 4, ConstraintId = 4 },
                    new FieldTypeConstraint() { Id = 10, FieldTypeId = 4, ConstraintId = 5 },
                    #endregion

                    #region Constraints for complex
                    new FieldTypeConstraint() { Id = 11, FieldTypeId = 5, ConstraintId = 6 },
                    new FieldTypeConstraint() { Id = 12, FieldTypeId = 5, ConstraintId = 7 },
                    new FieldTypeConstraint() { Id = 13, FieldTypeId = 5, ConstraintId = 8 },
                    new FieldTypeConstraint() { Id = 14, FieldTypeId = 5, ConstraintId = 9 },
                    #endregion

                    #region Constraints for string
                    new FieldTypeConstraint() { Id = 15, FieldTypeId = 6, ConstraintId = 17 },
                    new FieldTypeConstraint() { Id = 16, FieldTypeId = 6, ConstraintId = 18 },
                    new FieldTypeConstraint() { Id = 17, FieldTypeId = 6, ConstraintId = 11 },
                    new FieldTypeConstraint() { Id = 18, FieldTypeId = 6, ConstraintId = 12 },
                    #endregion

                    #region Constraints for date
                    new FieldTypeConstraint() { Id = 19, FieldTypeId = 8, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 20, FieldTypeId = 8, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 21, FieldTypeId = 8, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 22, FieldTypeId = 8, ConstraintId = 16 },
                    #endregion

                    #region Constraints for time
                    new FieldTypeConstraint() { Id = 23, FieldTypeId = 9, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 24, FieldTypeId = 9, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 25, FieldTypeId = 9, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 26, FieldTypeId = 9, ConstraintId = 16 },
                    #endregion

                    #region Constraints for datetime
                    new FieldTypeConstraint() { Id = 27, FieldTypeId = 10, ConstraintId = 13 },
                    new FieldTypeConstraint() { Id = 28, FieldTypeId = 10, ConstraintId = 14 },
                    new FieldTypeConstraint() { Id = 29, FieldTypeId = 10, ConstraintId = 15 },
                    new FieldTypeConstraint() { Id = 30, FieldTypeId = 10, ConstraintId = 16 },
                     #endregion

                    #region Constraints for guid
                    new FieldTypeConstraint() { Id = 31, FieldTypeId = 12, ConstraintId = 11 }
                    #endregion
                );

            modelBuilder.Entity<EncodingType>()
                .HasData(
                    new EncodingType() { Id = 1, Name = "UTF-8" },
                    new EncodingType() { Id = 2, Name = "UTF-16" },
                    new EncodingType() { Id = 3, Name = "UTF-32" }
                );

            #region Defined Datasets Seeds

            modelBuilder.Entity<DefinedDataset>()
                .HasData(
                    new DefinedDataset() { Id = 1, Name = "US_States", TypeId = 6 },
                    new DefinedDataset() { Id = 2, Name = "Programming Languages", TypeId = 6 },
                    new DefinedDataset() { Id = 3, Name = "Dog Breeds", TypeId = 6 },
                    new DefinedDataset() { Id = 4, Name = "Countries", TypeId = 6 },
                    new DefinedDataset() { Id = 5, Name = "First Names", TypeId = 6 },
                    new DefinedDataset() { Id = 6, Name = "Surnames", TypeId = 6 }
                );

            modelBuilder.Entity<Dataset>()
                .HasData(
                    new Dataset() { Id = 1, Name = "US_States", TypeId = 6, IsDefined = true },
                    new Dataset() { Id = 2, Name = "Programming Languages", TypeId = 6, IsDefined = true },
                    new Dataset() { Id = 3, Name = "Dog Breeds", TypeId = 6, IsDefined = true },
                    new Dataset() { Id = 4, Name = "Countries", TypeId = 6, IsDefined = true },
                    new Dataset() { Id = 5, Name = "First Names", TypeId = 6, IsDefined = true },
                    new Dataset() { Id = 6, Name = "Surnames", TypeId = 6, IsDefined = true }
                );

            modelBuilder.SeedStates();
            modelBuilder.SeedProgrammingLanguages();
            modelBuilder.SeedDogBreeds();
            modelBuilder.SeedCountries();
            modelBuilder.SeedFirstNames();
            modelBuilder.SeedSurnames();
            modelBuilder.SeedRegex();

            #endregion

            modelBuilder.Entity<DateTimeFormat>()
                .HasData(
                    new DateTimeFormat() { Id = 1, Value = "mm/dd/yy" },
                    new DateTimeFormat() { Id = 2, Value = "mm.dd.yy" },
                    new DateTimeFormat() { Id = 3, Value = "mm/dd/yyyy" },
                    new DateTimeFormat() { Id = 4, Value = "mm.dd.yyyy" },
                    new DateTimeFormat() { Id = 5, Value = "mm/yy" },
                    new DateTimeFormat() { Id = 6, Value = "mm.yy" },
                    new DateTimeFormat() { Id = 7, Value = "hh:mm" },
                    new DateTimeFormat() { Id = 8, Value = "hh:mm:sss" },
                    new DateTimeFormat() { Id = 9, Value = "yyyy/dd/mm" },
                    new DateTimeFormat() { Id = 10, Value = "yyyy.dd.mm" }
                );

            modelBuilder.Entity<Timezone>()
                .HasData(
                    new Timezone() { Id = 1, Value = "GMT"},
                    new Timezone() { Id = 2, Value = "UTC"}
                );

            modelBuilder.Entity<FileStatus>()
                .HasData(
                    new FileStatus() { Id = 1, Status = "NewFile" },
                    new FileStatus() { Id = 2, Status = "InProcessing" },
                    new FileStatus() { Id = 3, Status = "ProcessingFail" }
                );

            #region Sequences
            modelBuilder.HasSequence<int>("FileStatuses_Seq", schema: "public")
            .StartsAt(4)
            .IncrementsBy(1);

            modelBuilder.HasSequence<int>("EncodingTypes_Seq", schema: "public")
            .StartsAt(4)
            .IncrementsBy(1);

            modelBuilder.HasSequence<int>("FieldTypes_Seq", schema: "public")
            .StartsAt(13)
            .IncrementsBy(1);

            modelBuilder.HasSequence<int>("Constraints_Seq", schema: "public")
            .StartsAt(19)
            .IncrementsBy(1);

            modelBuilder.HasSequence<int>("FieldTypeConstraints_Seq", schema: "public")
            .StartsAt(32)
            .IncrementsBy(1);

            modelBuilder.HasSequence<int>("Datasets_Seq", "public")
                .StartsAt(7)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>("DefinedDatasets_Seq", "public")
                .StartsAt(7)
                .IncrementsBy(1);

            modelBuilder.HasSequence<int>("DefinedDatasetsValues_Seq", "public")
                .StartsAt(3868)
                .IncrementsBy(1);
            #endregion

            #region ApplySequences
            modelBuilder.Entity<FileStatus>()
            .Property(p => p.Id)
            .HasDefaultValueSql("nextval('\"FileStatuses_Seq\"')");

            modelBuilder.Entity<EncodingType>()
            .Property(p => p.Id)
            .HasDefaultValueSql("nextval('\"EncodingTypes_Seq\"')");
       
            modelBuilder.Entity<FieldType>()
            .Property(p => p.Id)
            .HasDefaultValueSql("nextval('\"FieldTypes_Seq\"')");

            modelBuilder.Entity<Constraint>()
            .Property(p => p.Id)
            .HasDefaultValueSql("nextval('\"Constraints_Seq\"')");

            modelBuilder.Entity<FieldTypeConstraint>()
            .Property(p => p.Id)
            .HasDefaultValueSql("nextval('\"FieldTypeConstraints_Seq\"')");

            modelBuilder.Entity<Dataset>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"Datasets_Seq\"')");

            modelBuilder.Entity<DefinedDataset>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"DefinedDatasets_Seq\"')");

            modelBuilder.Entity<DefinedDatasetValue>()
                .Property(p => p.Id)
                .HasDefaultValueSql("nextval('\"DefinedDatasetsValues_Seq\"')");
            #endregion
        }
    }
}
