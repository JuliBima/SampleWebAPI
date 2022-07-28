using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceWebAPI.Data.Migrations
{
    public partial class gantiidkatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Katalogs",
                newName: "KatalogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KatalogId",
                table: "Katalogs",
                newName: "Id");
        }
    }
}
