using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tara",
                table: "Producator");

            migrationBuilder.AddColumn<int>(
                name: "TaraID",
                table: "Producator",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tara",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masti = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vaccinuri = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Testare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ajutor_intreprinderi = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tara", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producator_TaraID",
                table: "Producator",
                column: "TaraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Producator_Tara_TaraID",
                table: "Producator",
                column: "TaraID",
                principalTable: "Tara",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producator_Tara_TaraID",
                table: "Producator");

            migrationBuilder.DropTable(
                name: "Tara");

            migrationBuilder.DropIndex(
                name: "IX_Producator_TaraID",
                table: "Producator");

            migrationBuilder.DropColumn(
                name: "TaraID",
                table: "Producator");

            migrationBuilder.AddColumn<string>(
                name: "Tara",
                table: "Producator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
