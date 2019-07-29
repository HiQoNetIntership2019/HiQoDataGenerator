using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_TimezoneTimeFormatSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DateTimeFormats",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "mm/dd/yy" },
                    { 2, "mm.dd.yy" },
                    { 3, "mm/dd/yyyy" },
                    { 4, "mm.dd.yyyy" },
                    { 5, "mm/yy" },
                    { 6, "mm.yy" },
                    { 7, "hh:mm" },
                    { 8, "hh:mm:sss" },
                    { 9, "yyyy/dd/mm" },
                    { 10, "yyyy.dd.mm" }
                });

            migrationBuilder.InsertData(
                table: "Timezones",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "GMT" },
                    { 2, "UTC" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DateTimeFormats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Timezones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Timezones",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
