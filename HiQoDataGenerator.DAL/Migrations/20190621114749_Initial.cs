using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncodingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncodingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regexes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Value = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regexes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timezones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timezones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types_Support_Constraints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    FieldTypeId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: true),
                    ConstraintId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types_Support_Constraints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Types_Support_Constraints_Constraints_ConstraintId",
                        column: x => x.ConstraintId,
                        principalTable: "Constraints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Types_Support_Constraints_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Types_Support_Constraints_ConstraintId",
                table: "Types_Support_Constraints",
                column: "ConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_Support_Constraints_TypeId",
                table: "Types_Support_Constraints",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncodingTypes");

            migrationBuilder.DropTable(
                name: "Regexes");

            migrationBuilder.DropTable(
                name: "Timezones");

            migrationBuilder.DropTable(
                name: "Types_Support_Constraints");

            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
