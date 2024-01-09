using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class VaccinTip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tip", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "VaccinTip",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VaccinID = table.Column<int>(type: "int", nullable: false),
                    TipID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinTip", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VaccinTip_Tip_TipID",
                        column: x => x.TipID,
                        principalTable: "Tip",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinTip_Vaccin_VaccinID",
                        column: x => x.VaccinID,
                        principalTable: "Vaccin",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinTip_TipID",
                table: "VaccinTip",
                column: "TipID");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinTip_VaccinID",
                table: "VaccinTip",
                column: "VaccinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinTip");

            migrationBuilder.DropTable(
                name: "Tip");
        }
    }
}
