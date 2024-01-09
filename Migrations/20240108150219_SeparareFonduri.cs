using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class SeparareFonduri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ajutor_intreprinderi",
                table: "Tara");

            migrationBuilder.DropColumn(
                name: "Masti",
                table: "Tara");

            migrationBuilder.DropColumn(
                name: "Ordin",
                table: "Tara");

            migrationBuilder.RenameColumn(
                name: "Vaccinuri",
                table: "Tara",
                newName: "Morti");

            migrationBuilder.RenameColumn(
                name: "Testare",
                table: "Tara",
                newName: "Cazuri");

            migrationBuilder.CreateTable(
                name: "Fond",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Masti = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Vaccinuri = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Testare = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Ajutor_intreprinderi = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TaraID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fond", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fond_Tara_TaraID",
                        column: x => x.TaraID,
                        principalTable: "Tara",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fond_TaraID",
                table: "Fond",
                column: "TaraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fond");

            migrationBuilder.RenameColumn(
                name: "Morti",
                table: "Tara",
                newName: "Vaccinuri");

            migrationBuilder.RenameColumn(
                name: "Cazuri",
                table: "Tara",
                newName: "Testare");

            migrationBuilder.AddColumn<decimal>(
                name: "Ajutor_intreprinderi",
                table: "Tara",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Masti",
                table: "Tara",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Ordin",
                table: "Tara",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
