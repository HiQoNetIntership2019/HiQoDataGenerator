using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_Sequences : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateSequence<int>(
                name: "Constraints_Seq",
                schema: "public",
                startValue: 19L);

            migrationBuilder.CreateSequence<int>(
                name: "EncodingTypes_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.CreateSequence<int>(
                name: "FieldTypeConstraints_Seq",
                schema: "public",
                startValue: 32L);

            migrationBuilder.CreateSequence<int>(
                name: "FieldTypes_Seq",
                schema: "public",
                startValue: 13L);

            migrationBuilder.CreateSequence<int>(
                name: "FileStatuses_Seq",
                schema: "public",
                startValue: 4L);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Types_Support_Constraints",
                nullable: false,
                defaultValueSql: "nextval('\"FieldTypeConstraints_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Types",
                nullable: false,
                defaultValueSql: "nextval('\"FieldTypes_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FileStatuses",
                nullable: false,
                defaultValueSql: "nextval('\"FileStatuses_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EncodingTypes",
                nullable: false,
                defaultValueSql: "nextval('\"EncodingTypes_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Constraints",
                nullable: false,
                defaultValueSql: "nextval('\"Constraints_Seq\"')",
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "Constraints_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "EncodingTypes_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "FieldTypeConstraints_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "FieldTypes_Seq",
                schema: "public");

            migrationBuilder.DropSequence(
                name: "FileStatuses_Seq",
                schema: "public");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Types_Support_Constraints",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"FieldTypeConstraints_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Types",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"FieldTypes_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "FileStatuses",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"FileStatuses_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EncodingTypes",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"EncodingTypes_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Constraints",
                nullable: false,
                oldClrType: typeof(int),
                oldDefaultValueSql: "nextval('\"Constraints_Seq\"')")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
