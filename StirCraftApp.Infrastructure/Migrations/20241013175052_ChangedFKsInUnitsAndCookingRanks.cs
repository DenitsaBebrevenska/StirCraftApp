using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFKsInUnitsAndCookingRanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_CookingRank_RankId",
                table: "Cooks");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients");

            migrationBuilder.RenameColumn(
                name: "RankId",
                table: "Cooks",
                newName: "CookingRankId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooks_RankId",
                table: "Cooks",
                newName: "IX_Cooks_CookingRankId");

            migrationBuilder.CreateTable(
                name: "RecipeRecipeIngredient",
                columns: table => new
                {
                    RecipeIngredientsId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeIngredient", x => new { x.RecipeIngredientsId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeIngredient_RecipeIngredients_RecipeIngredientsId",
                        column: x => x.RecipeIngredientsId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeRecipeIngredient_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DisplayName",
                table: "AspNetUsers",
                column: "DisplayName",
                unique: true,
                filter: "[DisplayName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeIngredient_RecipesId",
                table: "RecipeRecipeIngredient",
                column: "RecipesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_CookingRank_CookingRankId",
                table: "Cooks",
                column: "CookingRankId",
                principalTable: "CookingRank",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cooks_CookingRank_CookingRankId",
                table: "Cooks");

            migrationBuilder.DropTable(
                name: "RecipeRecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DisplayName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CookingRankId",
                table: "Cooks",
                newName: "RankId");

            migrationBuilder.RenameIndex(
                name: "IX_Cooks_CookingRankId",
                table: "Cooks",
                newName: "IX_Cooks_RankId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cooks_CookingRank_RankId",
                table: "Cooks",
                column: "RankId",
                principalTable: "CookingRank",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredients_Recipes_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
