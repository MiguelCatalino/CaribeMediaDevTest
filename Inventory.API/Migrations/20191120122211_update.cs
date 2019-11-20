using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventory.API.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_ItemCategoryCategoryID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemCategoryCategoryID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemCategoryCategoryID",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryID",
                table: "Items",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategoryID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_CategoryID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemCategoryCategoryID",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryCategoryID",
                table: "Items",
                column: "ItemCategoryCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_ItemCategoryCategoryID",
                table: "Items",
                column: "ItemCategoryCategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
