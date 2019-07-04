using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Create_CustomDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomDatasets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDatasets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomDatasetsValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Value = table.Column<string>(maxLength: 50, nullable: false),
                    DatasetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDatasetsValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomDatasetsValues_CustomDatasets_DatasetId",
                        column: x => x.DatasetId,
                        principalTable: "CustomDatasets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomDatasetsValues_DatasetId",
                table: "CustomDatasetsValues",
                column: "DatasetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomDatasetsValues");

            migrationBuilder.DropTable(
                name: "CustomDatasets");
        }
    }
}
