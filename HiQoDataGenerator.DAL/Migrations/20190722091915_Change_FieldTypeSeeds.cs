using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Change_FieldTypeSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 31,
                column: "FieldTypeId",
                value: 12);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 31,
                column: "FieldTypeId",
                value: 11);
        }
    }
}
