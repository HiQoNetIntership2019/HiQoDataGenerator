﻿// <auto-generated />
using System;
using HiQoDataGenerator.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190722091915_Change_FieldTypeSeeds")]
    partial class Change_FieldTypeSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:public.Constraints_Seq", "'Constraints_Seq', 'public', '19', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:public.EncodingTypes_Seq", "'EncodingTypes_Seq', 'public', '4', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:public.FieldTypeConstraints_Seq", "'FieldTypeConstraints_Seq', 'public', '32', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:public.FieldTypes_Seq", "'FieldTypes_Seq', 'public', '13', '1', '', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:public.FileStatuses_Seq", "'FileStatuses_Seq', 'public', '4', '1', '', '', 'Int32', 'False'");

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.Constraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"Constraints_Seq\"')");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Constraints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Minimal value for a numeric field.",
                            Name = "min value"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Maximal value for a numeric field.",
                            Name = "max value"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Comma or dot separator for a numeric field.",
                            Name = "separator"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Can be applied to a decimal field.",
                            Name = "max digits"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Separator position for a decimal field.",
                            Name = "decimal place"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Maximal re part value for a complex field.",
                            Name = "max a value"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Minimal re part value for a complex field.",
                            Name = "min a value"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Maximal img part value for a complex field.",
                            Name = "max b value"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Minimal img part value for a complex field.",
                            Name = "min b value"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Comma or dot separator for a numeric field.",
                            Name = "separator"
                        },
                        new
                        {
                            Id = 11,
                            Description = "Custom or defined regexp applied to a field.",
                            Name = "regex"
                        },
                        new
                        {
                            Id = 12,
                            Description = "Encoding type for a string field.",
                            Name = "encoding"
                        },
                        new
                        {
                            Id = 13,
                            Description = "The left boundary for date [time] field.",
                            Name = "start date"
                        },
                        new
                        {
                            Id = 14,
                            Description = "The right boundary for date [time] field.",
                            Name = "end date"
                        },
                        new
                        {
                            Id = 15,
                            Description = "Timezone applied to date [time] field.",
                            Name = "timezone"
                        },
                        new
                        {
                            Id = 16,
                            Description = "Representation format for a date [time] field.",
                            Name = "format"
                        },
                        new
                        {
                            Id = 17,
                            Description = "Minimal length of a string field.",
                            Name = "min length"
                        },
                        new
                        {
                            Id = 18,
                            Description = "Maximal length of a string field.",
                            Name = "max length"
                        });
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.ConstraintValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConstraintId");

                    b.Property<int?>("FieldId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("ConstraintId");

                    b.HasIndex("FieldId");

                    b.ToTable("ConstraintValues");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.DateTimeFormat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DateTimeFormats");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.EncodingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"EncodingTypes_Seq\"')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EncodingTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "UTF-8"
                        },
                        new
                        {
                            Id = 2,
                            Name = "UTF-16"
                        },
                        new
                        {
                            Id = 3,
                            Name = "UTF-32"
                        });
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.Regex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Regexes");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.Timezone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Timezones");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.ConfigurableObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateChange");

                    b.Property<DateTime>("DateCreation");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ConfigurableObject");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConfigurableObjectId");

                    b.Property<int?>("DatasetId");

                    b.Property<int?>("FieldTypeId");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("ConfigurableObjectId");

                    b.HasIndex("DatasetId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"FieldTypes_Seq\"')");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Byte"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Int"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Double"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Decimal"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Complex"
                        },
                        new
                        {
                            Id = 6,
                            Name = "String"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Bool"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Date"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Time"
                        },
                        new
                        {
                            Id = 10,
                            Name = "DateTime"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Enum"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Guid"
                        });
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.CustomDataset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("CustomDatasets");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.CustomDatasetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DatasetId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("DatasetId");

                    b.ToTable("CustomDatasetsValues");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.Dataset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDefined");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Datasets");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DatasetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DatasetTypes");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DefinedDataset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("DefinedDatasets");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DefinedDatasetValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DatasetId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("DatasetId");

                    b.ToTable("DefinedDatasetsValues");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.FileMetadataModels.FileMetadata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("StatusId");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("FilesMetadata");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.FileMetadataModels.FileStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"FileStatuses_Seq\"')");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("FileStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Status = "NewFile"
                        },
                        new
                        {
                            Id = 2,
                            Status = "InProcessing"
                        },
                        new
                        {
                            Id = 3,
                            Status = "ProcessingFail"
                        });
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.IntermediateModels.FieldTypeConstraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('\"FieldTypeConstraints_Seq\"')");

                    b.Property<int>("ConstraintId");

                    b.Property<int>("FieldTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ConstraintId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Types_Support_Constraints");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConstraintId = 1,
                            FieldTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            ConstraintId = 2,
                            FieldTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            ConstraintId = 1,
                            FieldTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            ConstraintId = 2,
                            FieldTypeId = 2
                        },
                        new
                        {
                            Id = 5,
                            ConstraintId = 1,
                            FieldTypeId = 3
                        },
                        new
                        {
                            Id = 6,
                            ConstraintId = 2,
                            FieldTypeId = 3
                        },
                        new
                        {
                            Id = 7,
                            ConstraintId = 3,
                            FieldTypeId = 3
                        },
                        new
                        {
                            Id = 8,
                            ConstraintId = 3,
                            FieldTypeId = 4
                        },
                        new
                        {
                            Id = 9,
                            ConstraintId = 4,
                            FieldTypeId = 4
                        },
                        new
                        {
                            Id = 10,
                            ConstraintId = 5,
                            FieldTypeId = 4
                        },
                        new
                        {
                            Id = 11,
                            ConstraintId = 6,
                            FieldTypeId = 5
                        },
                        new
                        {
                            Id = 12,
                            ConstraintId = 7,
                            FieldTypeId = 5
                        },
                        new
                        {
                            Id = 13,
                            ConstraintId = 8,
                            FieldTypeId = 5
                        },
                        new
                        {
                            Id = 14,
                            ConstraintId = 9,
                            FieldTypeId = 5
                        },
                        new
                        {
                            Id = 15,
                            ConstraintId = 17,
                            FieldTypeId = 6
                        },
                        new
                        {
                            Id = 16,
                            ConstraintId = 18,
                            FieldTypeId = 6
                        },
                        new
                        {
                            Id = 17,
                            ConstraintId = 11,
                            FieldTypeId = 6
                        },
                        new
                        {
                            Id = 18,
                            ConstraintId = 12,
                            FieldTypeId = 6
                        },
                        new
                        {
                            Id = 19,
                            ConstraintId = 13,
                            FieldTypeId = 8
                        },
                        new
                        {
                            Id = 20,
                            ConstraintId = 14,
                            FieldTypeId = 8
                        },
                        new
                        {
                            Id = 21,
                            ConstraintId = 15,
                            FieldTypeId = 8
                        },
                        new
                        {
                            Id = 22,
                            ConstraintId = 16,
                            FieldTypeId = 8
                        },
                        new
                        {
                            Id = 23,
                            ConstraintId = 13,
                            FieldTypeId = 9
                        },
                        new
                        {
                            Id = 24,
                            ConstraintId = 14,
                            FieldTypeId = 9
                        },
                        new
                        {
                            Id = 25,
                            ConstraintId = 15,
                            FieldTypeId = 9
                        },
                        new
                        {
                            Id = 26,
                            ConstraintId = 16,
                            FieldTypeId = 9
                        },
                        new
                        {
                            Id = 27,
                            ConstraintId = 13,
                            FieldTypeId = 10
                        },
                        new
                        {
                            Id = 28,
                            ConstraintId = 14,
                            FieldTypeId = 10
                        },
                        new
                        {
                            Id = 29,
                            ConstraintId = 15,
                            FieldTypeId = 10
                        },
                        new
                        {
                            Id = 30,
                            ConstraintId = 16,
                            FieldTypeId = 10
                        },
                        new
                        {
                            Id = 31,
                            ConstraintId = 11,
                            FieldTypeId = 12
                        });
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.ConstraintValue", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.ConstraintModels.Constraint", "Constraint")
                        .WithMany("Values")
                        .HasForeignKey("ConstraintId");

                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.Field", "Field")
                        .WithMany("ConstraintValues")
                        .HasForeignKey("FieldId");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.Field", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.ConfigurableObject", "ConfigurableObject")
                        .WithMany("Fields")
                        .HasForeignKey("ConfigurableObjectId");

                    b.HasOne("HiQoDataGenerator.DAL.Models.DataSetModels.Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId");

                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", "FieldType")
                        .WithMany()
                        .HasForeignKey("FieldTypeId");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.CustomDatasetValue", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.DataSetModels.CustomDataset", "Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.Dataset", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DefinedDataset", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DefinedDatasetValue", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.DataSetModels.DefinedDataset", "Dataset")
                        .WithMany()
                        .HasForeignKey("DatasetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.FileMetadataModels.FileMetadata", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.FileMetadataModels.FileStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.IntermediateModels.FieldTypeConstraint", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.ConstraintModels.Constraint", "Constraint")
                        .WithMany("SupportedTypes")
                        .HasForeignKey("ConstraintId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", "FieldType")
                        .WithMany("SupportedConstraints")
                        .HasForeignKey("FieldTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
