using Microsoft.EntityFrameworkCore.Migrations;

namespace RecipeBlogApp.Migrations
{
    public partial class DBInit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Recipes",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "RecipeCards",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Recipes",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "RecipeCards",
                newName: "ImageURL");
        }
    }
}
