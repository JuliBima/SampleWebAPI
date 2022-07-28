using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebAPI.Data.Migrations
{
    public partial class m2mkatalogproduk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KatalogProduk_Katalogs_KatalogsId",
                table: "KatalogProduk");

            migrationBuilder.DropForeignKey(
                name: "FK_KatalogProduk_Produks_ProduksId",
                table: "KatalogProduk");

            migrationBuilder.RenameColumn(
                name: "ProduksId",
                table: "KatalogProduk",
                newName: "ProdukId");

            migrationBuilder.RenameColumn(
                name: "KatalogsId",
                table: "KatalogProduk",
                newName: "KatalogId");

            migrationBuilder.RenameIndex(
                name: "IX_KatalogProduk_ProduksId",
                table: "KatalogProduk",
                newName: "IX_KatalogProduk_ProdukId");

            migrationBuilder.AddForeignKey(
                name: "FK_KatalogProduk_Katalogs_KatalogId",
                table: "KatalogProduk",
                column: "KatalogId",
                principalTable: "Katalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KatalogProduk_Produks_ProdukId",
                table: "KatalogProduk",
                column: "ProdukId",
                principalTable: "Produks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KatalogProduk_Katalogs_KatalogId",
                table: "KatalogProduk");

            migrationBuilder.DropForeignKey(
                name: "FK_KatalogProduk_Produks_ProdukId",
                table: "KatalogProduk");

            migrationBuilder.RenameColumn(
                name: "ProdukId",
                table: "KatalogProduk",
                newName: "ProduksId");

            migrationBuilder.RenameColumn(
                name: "KatalogId",
                table: "KatalogProduk",
                newName: "KatalogsId");

            migrationBuilder.RenameIndex(
                name: "IX_KatalogProduk_ProdukId",
                table: "KatalogProduk",
                newName: "IX_KatalogProduk_ProduksId");

            migrationBuilder.AddForeignKey(
                name: "FK_KatalogProduk_Katalogs_KatalogsId",
                table: "KatalogProduk",
                column: "KatalogsId",
                principalTable: "Katalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KatalogProduk_Produks_ProduksId",
                table: "KatalogProduk",
                column: "ProduksId",
                principalTable: "Produks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
