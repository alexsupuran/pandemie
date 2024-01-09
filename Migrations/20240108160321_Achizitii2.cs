using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Achizitii2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achizitie_Member_MemberID",
                table: "Achizitie");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Achizitie",
                newName: "MemberuID");

            migrationBuilder.RenameIndex(
                name: "IX_Achizitie_MemberID",
                table: "Achizitie",
                newName: "IX_Achizitie_MemberuID");

            migrationBuilder.CreateTable(
                name: "Memberu",
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
                    table.PrimaryKey("PK_Memberu", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Achizitie_Memberu_MemberuID",
                table: "Achizitie",
                column: "MemberuID",
                principalTable: "Memberu",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achizitie_Memberu_MemberuID",
                table: "Achizitie");

            migrationBuilder.DropTable(
                name: "Memberu");

            migrationBuilder.RenameColumn(
                name: "MemberuID",
                table: "Achizitie",
                newName: "MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Achizitie_MemberuID",
                table: "Achizitie",
                newName: "IX_Achizitie_MemberID");

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Achizitie_Member_MemberID",
                table: "Achizitie",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "ID");
        }
    }
}
