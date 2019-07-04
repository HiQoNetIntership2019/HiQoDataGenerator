using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class ConfObjectsFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConfigurableObjectId",
                table: "ConstraintValues",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldId",
                table: "ConstraintValues",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintValues_ConfigurableObjectId",
                table: "ConstraintValues",
                column: "ConfigurableObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstraintValues_FieldId",
                table: "ConstraintValues",
                column: "FieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConstraintValues_ConfigurableObject_ConfigurableObjectId",
                table: "ConstraintValues",
                column: "ConfigurableObjectId",
                principalTable: "ConfigurableObject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConstraintValues_Fields_FieldId",
                table: "ConstraintValues",
                column: "FieldId",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConstraintValues_ConfigurableObject_ConfigurableObjectId",
                table: "ConstraintValues");

            migrationBuilder.DropForeignKey(
                name: "FK_ConstraintValues_Fields_FieldId",
                table: "ConstraintValues");

            migrationBuilder.DropIndex(
                name: "IX_ConstraintValues_ConfigurableObjectId",
                table: "ConstraintValues");

            migrationBuilder.DropIndex(
                name: "IX_ConstraintValues_FieldId",
                table: "ConstraintValues");

            migrationBuilder.DropColumn(
                name: "ConfigurableObjectId",
                table: "ConstraintValues");

            migrationBuilder.DropColumn(
                name: "FieldId",
                table: "ConstraintValues");
        }
    }
}
