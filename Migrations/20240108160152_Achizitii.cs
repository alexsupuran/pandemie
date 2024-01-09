using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Achizitii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AchizitieID",
                table: "Vaccin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Achizitie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: true),
                    BookID = table.Column<int>(type: "int", nullable: true),
                    Data_achizitie = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achizitie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Achizitie_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccin_AchizitieID",
                table: "Vaccin",
                column: "AchizitieID",
                unique: true,
                filter: "[AchizitieID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Achizitie_MemberID",
                table: "Achizitie",
                column: "MemberID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccin_Achizitie_AchizitieID",
                table: "Vaccin",
                column: "AchizitieID",
                principalTable: "Achizitie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccin_Achizitie_AchizitieID",
                table: "Vaccin");

            migrationBuilder.DropTable(
                name: "Achizitie");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropIndex(
                name: "IX_Vaccin_AchizitieID",
                table: "Vaccin");

            migrationBuilder.DropColumn(
                name: "AchizitieID",
                table: "Vaccin");
        }
    }
}
