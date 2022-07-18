using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWebAPI.Data.Migrations
{
    public partial class m2mElementSword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Elements_ElementsElementId",
                table: "ElementSword");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Swords_SwordsId",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "SwordsId",
                table: "ElementSword",
                newName: "SwordId");

            migrationBuilder.RenameColumn(
                name: "ElementsElementId",
                table: "ElementSword",
                newName: "ElementId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_SwordsId",
                table: "ElementSword",
                newName: "IX_ElementSword_SwordId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Elements_ElementId",
                table: "ElementSword",
                column: "ElementId",
                principalTable: "Elements",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Swords_SwordId",
                table: "ElementSword",
                column: "SwordId",
                principalTable: "Swords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Elements_ElementId",
                table: "ElementSword");

            migrationBuilder.DropForeignKey(
                name: "FK_ElementSword_Swords_SwordId",
                table: "ElementSword");

            migrationBuilder.RenameColumn(
                name: "SwordId",
                table: "ElementSword",
                newName: "SwordsId");

            migrationBuilder.RenameColumn(
                name: "ElementId",
                table: "ElementSword",
                newName: "ElementsElementId");

            migrationBuilder.RenameIndex(
                name: "IX_ElementSword_SwordId",
                table: "ElementSword",
                newName: "IX_ElementSword_SwordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Elements_ElementsElementId",
                table: "ElementSword",
                column: "ElementsElementId",
                principalTable: "Elements",
                principalColumn: "ElementId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ElementSword_Swords_SwordsId",
                table: "ElementSword",
                column: "SwordsId",
                principalTable: "Swords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
