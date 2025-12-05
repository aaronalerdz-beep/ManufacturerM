using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplyNewModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "material",
                table: "parts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "machines",
                columns: table => new
                {
                    idseq = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name_machine = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    area = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_machines", x => x.idseq);
                });

            migrationBuilder.CreateTable(
                name: "production_orders",
                columns: table => new
                {
                    idseq = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    target_quantity = table.Column<int>(type: "integer", nullable: false),
                    final_quantity = table.Column<int>(type: "integer", nullable: false),
                    started_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    finished_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    partidseq = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_production_orders", x => x.idseq);
                    table.ForeignKey(
                        name: "fk_production_orders_parts_partidseq",
                        column: x => x.partidseq,
                        principalTable: "parts",
                        principalColumn: "idseq",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "machineconfigs",
                columns: table => new
                {
                    idseq = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pressure = table.Column<decimal>(type: "numeric", nullable: false),
                    grit = table.Column<int>(type: "integer", nullable: false),
                    cycle_duration = table.Column<decimal>(type: "numeric", nullable: false),
                    operator_name = table.Column<string>(type: "text", nullable: false),
                    machinesidseq = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_machineconfigs", x => x.idseq);
                    table.ForeignKey(
                        name: "fk_machineconfigs_machines_machinesidseq",
                        column: x => x.machinesidseq,
                        principalTable: "machines",
                        principalColumn: "idseq",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cycles",
                columns: table => new
                {
                    idseq = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    parts_per_cycle = table.Column<int>(type: "integer", nullable: false),
                    finished = table.Column<int>(type: "integer", nullable: false),
                    machineconfidseq = table.Column<int>(type: "integer", nullable: false),
                    productionorderidseq = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cycles", x => x.idseq);
                    table.ForeignKey(
                        name: "fk_cycles_machineconfigs_machineconfidseq",
                        column: x => x.machineconfidseq,
                        principalTable: "machineconfigs",
                        principalColumn: "idseq",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_cycles_production_orders_productionorderidseq",
                        column: x => x.productionorderidseq,
                        principalTable: "production_orders",
                        principalColumn: "idseq",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_cycles_machineconfidseq",
                table: "cycles",
                column: "machineconfidseq");

            migrationBuilder.CreateIndex(
                name: "ix_cycles_productionorderidseq",
                table: "cycles",
                column: "productionorderidseq");

            migrationBuilder.CreateIndex(
                name: "ix_machineconfigs_machinesidseq",
                table: "machineconfigs",
                column: "machinesidseq");

            migrationBuilder.CreateIndex(
                name: "ix_production_orders_partidseq",
                table: "production_orders",
                column: "partidseq");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cycles");

            migrationBuilder.DropTable(
                name: "machineconfigs");

            migrationBuilder.DropTable(
                name: "production_orders");

            migrationBuilder.DropTable(
                name: "machines");

            migrationBuilder.AlterColumn<string>(
                name: "material",
                table: "parts",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);
        }
    }
}
