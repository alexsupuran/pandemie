using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Vaccin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vaccin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret_achizitie = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Data_aprobare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Informatii = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccin", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Producator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaccinID = table.Column<int>(type: "int", nullable: true),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producator", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Producator_Vaccin_VaccinID",
                        column: x => x.VaccinID,
                        principalTable: "Vaccin",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producator_VaccinID",
                table: "Producator",
                column: "VaccinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producator");

            migrationBuilder.DropTable(
                name: "Vaccin");
        }
    }
}
