using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class SeedsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Constraints",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Minimal value for a numeric field.", "min value" },
                    { 18, "Maximal length of a string field.", "max length" },
                    { 17, "Minimal length of a string field.", "min length" },
                    { 16, "Representation format for a date [time] field.", "format" },
                    { 14, "The right boundary for date [time] field.", "end date" },
                    { 13, "The left boundary for date [time] field.", "start date" },
                    { 12, "Encoding type for a string field.", "encoding" },
                    { 11, "Custom or defined regexp applied to a field.", "regex" },
                    { 10, "Comma or dot separator for a numeric field.", "separator" },
                    { 15, "Timezone applied to date [time] field.", "timezone" },
                    { 8, "Maximal img part value for a complex field.", "max b value" },
                    { 7, "Minimal re part value for a complex field.", "min a value" },
                    { 6, "Maximal re part value for a complex field.", "max a value" },
                    { 5, "Separator position for a decimal field.", "decimal place" },
                    { 4, "Can be applied to a decimal field.", "max digits" },
                    { 3, "Comma or dot separator for a numeric field.", "separator" },
                    { 2, "Maximal value for a numeric field.", "max value" },
                    { 9, "Minimal img part value for a complex field.", "min b value" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "DateTime" },
                    { 9, "Time" },
                    { 8, "Date" },
                    { 7, "Bool" },
                    { 6, "String" },
                    { 2, "Int" },
                    { 4, "Decimal" },
                    { 3, "Double" },
                    { 1, "Byte" },
                    { 11, "Enum" },
                    { 5, "Complex" },
                    { 12, "Guid" }
                });

            migrationBuilder.InsertData(
                table: "Types_Support_Constraints",
                columns: new[] { "Id", "ConstraintId", "FieldTypeId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 29, 15, 10 },
                    { 28, 14, 10 },
                    { 27, 13, 10 },
                    { 26, 16, 9 },
                    { 25, 15, 9 },
                    { 24, 14, 9 },
                    { 23, 13, 9 },
                    { 22, 16, 8 },
                    { 21, 15, 8 },
                    { 20, 14, 8 },
                    { 19, 13, 8 },
                    { 18, 12, 6 },
                    { 17, 11, 6 },
                    { 30, 16, 10 },
                    { 16, 18, 6 },
                    { 14, 9, 5 },
                    { 13, 8, 5 },
                    { 12, 7, 5 },
                    { 11, 6, 5 },
                    { 10, 5, 4 },
                    { 9, 4, 4 },
                    { 8, 3, 4 },
                    { 7, 3, 3 },
                    { 6, 2, 3 },
                    { 5, 1, 3 },
                    { 4, 2, 2 },
                    { 3, 1, 2 },
                    { 2, 2, 1 },
                    { 15, 17, 6 },
                    { 31, 11, 11 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Types_Support_Constraints",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Constraints",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
