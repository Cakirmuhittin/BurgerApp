using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.Data.Migrations
{
    public partial class Mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "Menuler",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resim",
                table: "ExtraMalzemeler",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Resim",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "Resim",
                table: "ExtraMalzemeler");
        }
    }
}
