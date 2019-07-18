using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_DatasetFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DatasetId",
                table: "Fields",
                nullable: true);
            
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
            
            migrationBuilder.DropColumn(
                name: "DatasetId",
                table: "Fields");
        }
    }
}
