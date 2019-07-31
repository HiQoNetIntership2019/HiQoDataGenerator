using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_DatasetSequences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "Datasets_Seq",
                schema: "public",
                startValue: 7L);

            migrationBuilder.CreateSequence<int>(
                name: "DefinedDatasets_Seq",
                schema: "public",
                startValue: 7L);

            migrationBuilder.CreateSequence<int>(
                name: "DefinedDatasetsValues_Seq",
                schema: "public",
                startValue: 3868L);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DefinedDatasetsValues",
                nullable: false,
                defaultValueSql: "nextval('\"DefinedDatasetsValues_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DefinedDatasets",
                nullable: false,
                defaultValueSql: "nextval('\"DefinedDatasets_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Datasets",
                nullable: false,
                defaultValueSql: "nextval('\"Datasets_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Datasets_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "DefinedDatasets_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "DefinedDatasetsValues_Seq",
                schema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DefinedDatasetsValues",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"DefinedDatasetsValues_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "DefinedDatasets",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"DefinedDatasets_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Datasets",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"Datasets_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
