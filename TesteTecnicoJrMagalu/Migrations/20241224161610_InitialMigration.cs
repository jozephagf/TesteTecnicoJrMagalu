using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteTecnicoJrMagalu.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cte",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    det_cMunIni = table.Column<int>(type: "integer", nullable: true),
                    det_xMunIni = table.Column<string>(type: "text", nullable: true),
                    ide_UFIni = table.Column<string>(type: "text", nullable: true),
                    ide_cMunEnv = table.Column<int>(type: "integer", nullable: false),
                    ide_xMunEnv = table.Column<string>(type: "text", nullable: true),
                    det_cMunFim = table.Column<int>(type: "integer", nullable: false),
                    det_xMunFim = table.Column<string>(type: "text", nullable: true),
                    ide_UFFim = table.Column<string>(type: "text", nullable: true),
                    ide_dhEmi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ide_dist_KM = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cte", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CteInfCargaInfQ",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_cte = table.Column<int>(type: "integer", nullable: false),
                    infCarga_infQ_cUnid = table.Column<string>(type: "text", nullable: true),
                    infCarga_infQ_tpMed = table.Column<string>(type: "text", nullable: true),
                    infCarga_infQ_qCarga = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CteInfCargaInfQ", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cte");

            migrationBuilder.DropTable(
                name: "CteInfCargaInfQ");
        }
    }
}
