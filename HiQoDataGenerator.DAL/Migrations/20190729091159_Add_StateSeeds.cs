using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_StateSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Datasets",
                columns: new[] { "Id", "IsDefined", "Name", "TypeId" },
                values: new object[] { 1, true, "US_States", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasets",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 1, "US_States", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasetsValues",
                columns: new[] { "Id", "DatasetId", "Value" },
                values: new object[,]
                {
                    { 1, 1, "Alabama" },
                    { 29, 1, "North Dakota" },
                    { 30, 1, "Ohio" },
                    { 31, 1, "Oklahoma" },
                    { 32, 1, "Oregon" },
                    { 33, 1, "Maryland" },
                    { 34, 1, "Massachusetts" },
                    { 35, 1, "Michigan" },
                    { 36, 1, "Minnesota" },
                    { 37, 1, "Mississippi" },
                    { 38, 1, "Missouri" },
                    { 39, 1, "Pennsylvania" },
                    { 40, 1, "Rhode Island" },
                    { 41, 1, "South Carolina" },
                    { 42, 1, "South Dakota" },
                    { 43, 1, "Tennessee" },
                    { 44, 1, "Texas" },
                    { 45, 1, "Utah" },
                    { 46, 1, "Vermont" },
                    { 47, 1, "Virginia" },
                    { 48, 1, "Washington" },
                    { 49, 1, "West Virginia" },
                    { 28, 1, "North Carolina" },
                    { 27, 1, "New York" },
                    { 26, 1, "New Mexico" },
                    { 25, 1, "New Jersey" },
                    { 3, 1, "Arizona" },
                    { 4, 1, "Arkansas" },
                    { 5, 1, "California" },
                    { 6, 1, "Colorado" },
                    { 7, 1, "Connecticut" },
                    { 8, 1, "Delaware" },
                    { 9, 1, "District of Columbia" },
                    { 10, 1, "Florida" },
                    { 11, 1, "Georgia" },
                    { 12, 1, "Hawaii" },
                    { 50, 1, "Wisconsin" },
                    { 13, 1, "Idaho" },
                    { 15, 1, "Indiana" },
                    { 16, 1, "Iowa" },
                    { 17, 1, "Kansas" },
                    { 18, 1, "Kentucky" },
                    { 19, 1, "Louisiana" },
                    { 20, 1, "Maine" },
                    { 21, 1, "Montana" },
                    { 22, 1, "Nebraska" },
                    { 23, 1, "Nevada" },
                    { 24, 1, "New Hampshire" },
                    { 14, 1, "Illinois" },
                    { 51, 1, "Wyoming" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Datasets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "DefinedDatasets",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
