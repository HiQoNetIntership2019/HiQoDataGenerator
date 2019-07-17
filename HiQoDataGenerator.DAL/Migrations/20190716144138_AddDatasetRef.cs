using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class AddDatasetRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatasetId",
                table: "Fields",
                nullable: true);

            migrationBuilder.InsertData(
                table: "FileStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[,]
                {
                    { 1, "NewFile" },
                    { 2, "InProcessing" },
                    { 3, "ProcessingFail" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fields_DatasetId",
                table: "Fields",
                column: "DatasetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_Datasets_DatasetId",
                table: "Fields",
                column: "DatasetId",
                principalTable: "Datasets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_Datasets_DatasetId",
                table: "Fields");

            migrationBuilder.DropIndex(
                name: "IX_Fields_DatasetId",
                table: "Fields");

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FileStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DatasetId",
                table: "Fields");
        }
    }
}
