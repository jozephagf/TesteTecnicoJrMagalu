using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoJrMagalu.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableCteAddICMSAndTotalCteColumnsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ICMS_CST",
                table: "Cte",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ICMS_pICMS",
                table: "Cte",
                type: "numeric(11,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ICMS_vBC",
                table: "Cte",
                type: "numeric(11,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ICMS_vICMS",
                table: "Cte",
                type: "numeric(11,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TOTALvCTe",
                table: "Cte",
                type: "numeric(11,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ICMS_CST",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "ICMS_pICMS",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "ICMS_vBC",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "ICMS_vICMS",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "TOTALvCTe",
                table: "Cte");
        }
    }
}
