using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Remove_Separator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Constraints",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Comma or dot separator for a numeric field.", "separator" },
                    { 10, "Comma or dot separator for a numeric field.", "separator" }
                });

            migrationBuilder.InsertData(
                table: "Types_Support_Constraints",
                columns: new[] { "Id", "ConstraintId", "FieldTypeId" },
                values: new object[,]
                {
                    { 7, 3, 3 },
                    { 8, 3, 4 }
                });
        }
    }
}
