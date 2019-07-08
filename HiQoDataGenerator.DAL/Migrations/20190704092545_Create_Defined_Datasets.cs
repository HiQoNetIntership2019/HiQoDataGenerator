using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Create_Defined_Datasets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurableObject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    DateChange = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurableObject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConstraintValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Value = table.Column<string>(maxLength: 300, nullable: false),
                    ConstraintId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstraintValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConstraintValues_Constraints_ConstraintId",
                        column: x => x.ConstraintId,
                        principalTable: "Constraints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            
            migrationBuilder.CreateTable(
                name: "DefinedDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinedDatasets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefinedDatasets_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    FieldTypeId = table.Column<int>(nullable: true),
                    ConfigurableObjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_ConfigurableObject_ConfigurableObjectId",
                        column: x => x.ConfigurableObjectId,
                        principalTable: "ConfigurableObject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fields_Types_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DefinedDatasetsValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Value = table.Column<string>(maxLength: 150, nullable: false),
                    DatasetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefinedDatasetsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefinedDatasetsValues_DefinedDatasets_DatasetId",
                        column: x => x.DatasetId,
                        principalTable: "DefinedDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintValues_ConstraintId",
                table: "ConstraintValues",
                column: "ConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_DefinedDatasets_TypeId",
                table: "DefinedDatasets",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DefinedDatasetsValues_DatasetId",
                table: "DefinedDatasetsValues",
                column: "DatasetId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_ConfigurableObjectId",
                table: "Fields",
                column: "ConfigurableObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_FieldTypeId",
                table: "Fields",
                column: "FieldTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConstraintValues");
            
            migrationBuilder.DropTable(
                name: "DefinedDatasetsValues");

            migrationBuilder.DropTable(
                name: "Fields");

            migrationBuilder.DropTable(
                name: "DefinedDatasets");

            migrationBuilder.DropTable(
                name: "ConfigurableObject");
        }
    }
}
