using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.Data.Migrations
{
    public partial class Mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraMalzemeler_Siparisler_SiparisId",
                table: "ExtraMalzemeler");

            migrationBuilder.RenameColumn(
                name: "SiparisId",
                table: "ExtraMalzemeler",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraMalzemeler_SiparisId",
                table: "ExtraMalzemeler",
                newName: "IX_ExtraMalzemeler_MenuId");

            migrationBuilder.CreateTable(
                name: "Extralar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    EkstraId = table.Column<int>(type: "int", nullable: false),
                    ExtraMalzemelersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extralar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extralar_ExtraMalzemeler_ExtraMalzemelersId",
                        column: x => x.ExtraMalzemelersId,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Extralar_Menuler_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraMalzemeSiparis",
                columns: table => new
                {
                    ExtraMalzemeId = table.Column<int>(type: "int", nullable: false),
                    SiparislerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemeSiparis", x => new { x.ExtraMalzemeId, x.SiparislerId });
                    table.ForeignKey(
                        name: "FK_ExtraMalzemeSiparis_ExtraMalzemeler_ExtraMalzemeId",
                        column: x => x.ExtraMalzemeId,
                        principalTable: "ExtraMalzemeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemeSiparis_Siparisler_SiparislerId",
                        column: x => x.SiparislerId,
                        principalTable: "Siparisler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Extralar_ExtraMalzemelersId",
                table: "Extralar",
                column: "ExtraMalzemelersId");

            migrationBuilder.CreateIndex(
                name: "IX_Extralar_MenuId",
                table: "Extralar",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemeSiparis_SiparislerId",
                table: "ExtraMalzemeSiparis",
                column: "SiparislerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraMalzemeler_Menuler_MenuId",
                table: "ExtraMalzemeler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExtraMalzemeler_Menuler_MenuId",
                table: "ExtraMalzemeler");

            migrationBuilder.DropTable(
                name: "Extralar");

            migrationBuilder.DropTable(
                name: "ExtraMalzemeSiparis");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "ExtraMalzemeler",
                newName: "SiparisId");

            migrationBuilder.RenameIndex(
                name: "IX_ExtraMalzemeler_MenuId",
                table: "ExtraMalzemeler",
                newName: "IX_ExtraMalzemeler_SiparisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraMalzemeler_Siparisler_SiparisId",
                table: "ExtraMalzemeler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id");
        }
    }
}
