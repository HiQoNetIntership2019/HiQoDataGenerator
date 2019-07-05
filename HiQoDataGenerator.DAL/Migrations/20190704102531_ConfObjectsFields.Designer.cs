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
    [Migration("20190704102531_ConfObjectsFields")]
    partial class ConfObjectsFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.Constraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Constraints");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.ConstraintValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ConfigurableObjectId");

                    b.Property<int?>("ConstraintId");

                    b.Property<int?>("FieldId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("ConfigurableObjectId");

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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("EncodingTypes");
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

                    b.Property<int?>("FieldTypeId");

                    b.Property<bool>("IsRequired");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("ConfigurableObjectId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.FieldType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Types");
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

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.DataSetModels.DatasetType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DatasetType");
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

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.IntermediateModels.FieldTypeConstraint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ConstraintId");

                    b.Property<int>("FieldTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ConstraintId");

                    b.HasIndex("FieldTypeId");

                    b.ToTable("Types_Support_Constraints");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.ConstraintModels.ConstraintValue", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.ConfigurableObject")
                        .WithMany("ConstraintValues")
                        .HasForeignKey("ConfigurableObjectId");

                    b.HasOne("HiQoDataGenerator.DAL.Models.ConstraintModels.Constraint", "Constraint")
                        .WithMany("Values")
                        .HasForeignKey("ConstraintId");

                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.Field", "Field")
                        .WithMany()
                        .HasForeignKey("FieldId");
                });

            modelBuilder.Entity("HiQoDataGenerator.DAL.Models.CustomObjectModels.Field", b =>
                {
                    b.HasOne("HiQoDataGenerator.DAL.Models.CustomObjectModels.ConfigurableObject", "ConfigurableObject")
                        .WithMany("Fields")
                        .HasForeignKey("ConfigurableObjectId");

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
