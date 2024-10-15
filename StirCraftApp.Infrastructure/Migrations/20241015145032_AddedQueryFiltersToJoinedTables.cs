using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedQueryFiltersToJoinedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavoriteRecipes_AspNetUsers_AppUserId",
                table: "UsersFavoriteRecipes");

            migrationBuilder.DropIndex(
                name: "IX_UsersFavoriteRecipes_AppUserId",
                table: "UsersFavoriteRecipes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "UsersFavoriteRecipes");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavoriteRecipes_AspNetUsers_UserId",
                table: "UsersFavoriteRecipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFavoriteRecipes_AspNetUsers_UserId",
                table: "UsersFavoriteRecipes");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "UsersFavoriteRecipes",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteRecipes_AppUserId",
                table: "UsersFavoriteRecipes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFavoriteRecipes_AspNetUsers_AppUserId",
                table: "UsersFavoriteRecipes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
