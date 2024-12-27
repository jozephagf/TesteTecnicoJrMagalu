using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteTecnicoJrMagalu.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableCteAddNewColumnsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"Cte\" ADD IF NOT EXISTS \"vFretePorTonelada\" numeric(11, 2) NOT NULL DEFAULT 0.0");
            migrationBuilder.Sql("ALTER TABLE \"Cte\" ADD IF NOT EXISTS \"vOutrasDesp\" numeric(11, 2) NOT NULL DEFAULT 0.0");

            migrationBuilder.AddColumn<decimal>(
                name: "TOTALvFrete",
                table: "Cte",
                type: "numeric(11,2)",
                nullable: false,
                defaultValue: 0m,
                defaultValueSql: "0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "vFretePorTonelada",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "vOutrasDesp",
                table: "Cte");

            migrationBuilder.DropColumn(
                name: "TOTALvFrete",
                table: "Cte");
        }
    }
}
