using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class gantinama : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tipes");

            migrationBuilder.CreateTable(
                name: "TypeSwords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSwords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeSwords_Swords_SwordId",
                        column: x => x.SwordId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TypeSwords_SwordId",
                table: "TypeSwords",
                column: "SwordId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeSwords");

            migrationBuilder.CreateTable(
                name: "Tipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SwordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tipes_Swords_SwordId",
                        column: x => x.SwordId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tipes_SwordId",
                table: "Tipes",
                column: "SwordId",
                unique: true);
        }
    }
}
