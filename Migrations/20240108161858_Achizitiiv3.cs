using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pandemie.Migrations
{
    public partial class Achizitiiv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "Achizitie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "Achizitie");
        }
    }
}
