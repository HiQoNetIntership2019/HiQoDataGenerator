using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class UpdateConfObj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstraintValues_ConfigurableObject_ConfigurableObjectId",
                table: "ConstraintValues");

            migrationBuilder.DropIndex(
                name: "IX_ConstraintValues_ConfigurableObjectId",
                table: "ConstraintValues");

            migrationBuilder.DropColumn(
                name: "ConfigurableObjectId",
                table: "ConstraintValues");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfigurableObjectId",
                table: "ConstraintValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintValues_ConfigurableObjectId",
                table: "ConstraintValues",
                column: "ConfigurableObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstraintValues_ConfigurableObject_ConfigurableObjectId",
                table: "ConstraintValues",
                column: "ConfigurableObjectId",
                principalTable: "ConfigurableObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
