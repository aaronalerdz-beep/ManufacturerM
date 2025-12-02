using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplyPostgresNamingConvention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parts",
                table: "Parts");

            migrationBuilder.RenameTable(
                name: "Parts",
                newName: "parts");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "parts",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Sequence",
                table: "parts",
                newName: "sequence");

            migrationBuilder.RenameColumn(
                name: "PartNum",
                table: "parts",
                newName: "partnum");

            migrationBuilder.RenameColumn(
                name: "Material",
                table: "parts",
                newName: "material");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "parts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "IdSeq",
                table: "parts",
                newName: "idseq");

            migrationBuilder.AddPrimaryKey(
                name: "pk_parts",
                table: "parts",
                column: "idseq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_parts",
                table: "parts");

            migrationBuilder.RenameTable(
                name: "parts",
                newName: "Parts");

            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Parts",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "sequence",
                table: "Parts",
                newName: "Sequence");

            migrationBuilder.RenameColumn(
                name: "partnum",
                table: "Parts",
                newName: "PartNum");

            migrationBuilder.RenameColumn(
                name: "material",
                table: "Parts",
                newName: "Material");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Parts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "idseq",
                table: "Parts",
                newName: "IdSeq");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parts",
                table: "Parts",
                column: "IdSeq");
        }
    }
}
