using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    IdSeq = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PartNum = table.Column<string>(type: "text", nullable: true, computedColumnSql: "'PN-' || lpad(\"IdSeq\"::text, 6, '0')", stored: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Material = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Sequence = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Weight = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.IdSeq);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parts");
        }
    }
}
