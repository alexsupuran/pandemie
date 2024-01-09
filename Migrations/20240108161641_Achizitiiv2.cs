using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Achizitiiv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccin_Achizitie_AchizitieID",
                table: "Vaccin");

            migrationBuilder.DropIndex(
                name: "IX_Vaccin_AchizitieID",
                table: "Vaccin");

            migrationBuilder.DropColumn(
                name: "AchizitieID",
                table: "Vaccin");

            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Achizitie",
                newName: "VaccinID");

            migrationBuilder.CreateIndex(
                name: "IX_Achizitie_VaccinID",
                table: "Achizitie",
                column: "VaccinID");

            migrationBuilder.AddForeignKey(
                name: "FK_Achizitie_Vaccin_VaccinID",
                table: "Achizitie",
                column: "VaccinID",
                principalTable: "Vaccin",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achizitie_Vaccin_VaccinID",
                table: "Achizitie");

            migrationBuilder.DropIndex(
                name: "IX_Achizitie_VaccinID",
                table: "Achizitie");

            migrationBuilder.RenameColumn(
                name: "VaccinID",
                table: "Achizitie",
                newName: "BookID");

            migrationBuilder.AddColumn<int>(
                name: "AchizitieID",
                table: "Vaccin",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccin_AchizitieID",
                table: "Vaccin",
                column: "AchizitieID",
                unique: true,
                filter: "[AchizitieID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccin_Achizitie_AchizitieID",
                table: "Vaccin",
                column: "AchizitieID",
                principalTable: "Achizitie",
                principalColumn: "ID");
        }
    }
}
