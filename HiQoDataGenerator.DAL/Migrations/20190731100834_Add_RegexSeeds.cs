using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_RegexSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regexes",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { 1, "Belarusian phone № (opt.code)", "^\\+375\\((17|25|29|33|44)\\)\\d{3}-?\\d{2}-?\\d{2}$" },
                    { 16, "Guid in braces", "^\\{[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}\\}" },
                    { 15, "Guid with '-'", "^[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}$" },
                    { 14, "Password", "^\\w(\\.|\\*|\\?|\\d|\\w|[!@#$%]){7,19}$" },
                    { 13, "Simplified Email", "^((\\w|\\d)(\\w|\\d|\\-|\\.)?(\\w|\\d)+)+@{1}(((\\w|\\d|\\-){1,67})|((\\w|\\d|\\-)+\\\\.(\\w|\\d|\\-){1,67}))\\.(([a-zA-Z0-9]{2,4})(\\.[a-zA-Z0-9]{2})?)$" },
                    { 12, "Email: RFC822", "^(\\w[a-z0-9!#$%&'*\\+/=\\?\\^_`{|}~]+(\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*)@([a-z0-9]([a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9]([a-z0-9-]*[a-z0-9])?|\\[((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9])$" },
                    { 11, "DateTime: YYYY/MM/DD [T]HH:MM:SS", "^20\\d{2}/((0[1-9])|(1[0-2]))/((0[1-9])|([1-2][0-9])|(3[0-1])) (T| )(([0-1][0-9])|(2[0-3])):([0-5][0-9]):([0-5][0-9])$" },
                    { 10, "Time: HH:MM:SS", "^(([0-1][0-9])|([2][0-3])):([0-5][0-9]):([0-5][0-9])$" },
                    { 9, "Time: HH(:|.)MM[(:|.)SS] [AM|PM]", "^(([0]?[1-9]|1[0-2])(:|\\.)[0-5][0-9]((:|\\.)[0-5][0-9])?( )?(AM|am|aM|Am|PM|pm|pM|Pm))$" },
                    { 8, "Time: HH:MM | HH/MM", "^([0-1][0-9]|[2][0-3])[:/\\.]([0-5][0-9])$" },
                    { 7, "Date: YYYY/MM/DD with leap years", "^(((19|20)([2468][048]|[13579][26]|0[48])|2000)/02/29|((19|20)[0-9]{2}/(0[469]|11)/(0[1-9]|[12][0-9]|30)|(19|20)[0-9]{2}/(0[13578]|1[02])/(0[1-9]|[12][0-9]|3[01])|(19|20)[0-9]{2}/02/(0[1-9]|1[0-9]|2[0-8])))$" },
                    { 6, "Date: DD Mon YYYY", "^(([012]\\d|30) (Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)|31 (Jan|Mar|May|Jul|Aug|Oct|Dec)|[012]\\d Feb) [012]\\d{3}$" },
                    { 5, "Date: MM/(Y)YYY", "^((0[1-9])|(1[012]))/[12]?\\d{3}$" },
                    { 4, "URL with http(s)", "^https?://[A-Za-z]+(-?([A-Za-z]|\\d)+)+\\.([A-Za-z]|\\d)+(-?([A-Za-z]|\\d)+)*\\.(com|net|by|ru|uk|biz|kr)/(([A-Za-z]|\\d)+(-?([A-Za-z]|\\d)+)*)+/{0,1}$" },
                    { 3, "UK phone №", "^((\\+0?44\\-?)?(\\(0\\))|0)((20[78]{1}\\)?\\-?[1-9]{1}[0-9]{2}\\-?[0-9]{4})|([1-8]{1}[0-9]{3}\\)?\\-?[1-9]{1}[0-9]{2}\\-?[0-9]{3}))$" },
                    { 2, "US phone №", "^(\\([2-9]\\d{2}\\)|[2-9]\\d{2})\\-?[2-9]\\d{2}\\-?\\d{4}$" },
                    { 17, "SSN with hyphens", "^\\d{3}-\\d{2}-\\d{4}$" },
                    { 18, "Simple SSN", "^\\d{9}$" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Regexes",
                keyColumn: "Id",
                keyValue: 18);
        }
    }
}
