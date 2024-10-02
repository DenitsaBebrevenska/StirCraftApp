using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FilteredIndexingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShoppingList_IsDeleted",
                table: "ShoppingList",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Replies_IsDeleted",
                table: "Replies",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IsDeleted",
                table: "Recipes",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRatings_IsDeleted",
                table: "RecipeRatings",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeImages_IsDeleted",
                table: "RecipeImages",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementUnits_IsDeleted",
                table: "MeasurementUnits",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IsDeleted",
                table: "Ingredients",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_IsDeleted",
                table: "Cooks",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_CookingRank_IsDeleted",
                table: "CookingRank",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted",
                filter: "[IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ShoppingList_IsDeleted",
                table: "ShoppingList");

            migrationBuilder.DropIndex(
                name: "IX_Replies_IsDeleted",
                table: "Replies");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IsDeleted",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_RecipeRatings_IsDeleted",
                table: "RecipeRatings");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeImages_IsDeleted",
                table: "RecipeImages");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementUnits_IsDeleted",
                table: "MeasurementUnits");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IsDeleted",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Cooks_IsDeleted",
                table: "Cooks");

            migrationBuilder.DropIndex(
                name: "IX_CookingRank_IsDeleted",
                table: "CookingRank");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IsDeleted",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers");
        }
    }
}
