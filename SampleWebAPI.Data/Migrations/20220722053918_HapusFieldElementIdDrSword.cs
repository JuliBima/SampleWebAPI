using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class HapusFieldElementIdDrSword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementId",
                table: "Swords");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElementId",
                table: "Swords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
