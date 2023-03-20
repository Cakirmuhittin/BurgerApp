using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BurgerApp.Data.Migrations
{
    public partial class Mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siparisler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeciliMenuId = table.Column<int>(type: "int", nullable: false),
                    Boyutu = table.Column<int>(type: "int", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siparisler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Siparisler_Menuler_SeciliMenuId",
                        column: x => x.SeciliMenuId,
                        principalTable: "Menuler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraMalzemeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraMalzemeAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraMalzemeFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SiparisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMalzemeler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExtraMalzemeler_Siparisler_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "Siparisler",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMalzemeler_SiparisId",
                table: "ExtraMalzemeler",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_Siparisler_SeciliMenuId",
                table: "Siparisler",
                column: "SeciliMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMalzemeler");

            migrationBuilder.DropTable(
                name: "Siparisler");

            migrationBuilder.DropTable(
                name: "Menuler");
        }
    }
}
