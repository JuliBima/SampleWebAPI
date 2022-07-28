using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebAPI.Data.Migrations
{
    public partial class merubahprodukkatalogm2m : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Katalogs_Produks_ProdukId",
                table: "Katalogs");

            migrationBuilder.DropIndex(
                name: "IX_Katalogs_ProdukId",
                table: "Katalogs");

            migrationBuilder.DropColumn(
                name: "ProdukId",
                table: "Katalogs");

            migrationBuilder.CreateTable(
                name: "KatalogProduk",
                columns: table => new
                {
                    KatalogsId = table.Column<int>(type: "int", nullable: false),
                    ProduksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KatalogProduk", x => new { x.KatalogsId, x.ProduksId });
                    table.ForeignKey(
                        name: "FK_KatalogProduk_Katalogs_KatalogsId",
                        column: x => x.KatalogsId,
                        principalTable: "Katalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KatalogProduk_Produks_ProduksId",
                        column: x => x.ProduksId,
                        principalTable: "Produks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KatalogProduk_ProduksId",
                table: "KatalogProduk",
                column: "ProduksId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KatalogProduk");

            migrationBuilder.AddColumn<int>(
                name: "ProdukId",
                table: "Katalogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Katalogs_ProdukId",
                table: "Katalogs",
                column: "ProdukId");

            migrationBuilder.AddForeignKey(
                name: "FK_Katalogs_Produks_ProdukId",
                table: "Katalogs",
                column: "ProdukId",
                principalTable: "Produks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
