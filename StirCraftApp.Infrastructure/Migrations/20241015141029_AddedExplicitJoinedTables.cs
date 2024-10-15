using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedExplicitJoinedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUserRecipe");

            migrationBuilder.DropTable(
                name: "CategoryRecipe");

            migrationBuilder.DropTable(
                name: "RecipeIngredientShoppingList");

            migrationBuilder.CreateTable(
                name: "CategoriesRecipes",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesRecipes", x => new { x.CategoryId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_CategoriesRecipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoriesRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListsRecipeIngredients",
                columns: table => new
                {
                    ShoppingListId = table.Column<int>(type: "int", nullable: false),
                    RecipeIngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingListsRecipeIngredients", x => new { x.ShoppingListId, x.RecipeIngredientId });
                    table.ForeignKey(
                        name: "FK_ShoppingListsRecipeIngredients_RecipeIngredients_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingListsRecipeIngredients_ShoppingLists_ShoppingListId",
                        column: x => x.ShoppingListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsersFavoriteRecipes",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersFavoriteRecipes", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_UsersFavoriteRecipes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UsersFavoriteRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesRecipes_RecipeId",
                table: "CategoriesRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListsRecipeIngredients_RecipeIngredientId",
                table: "ShoppingListsRecipeIngredients",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteRecipes_AppUserId",
                table: "UsersFavoriteRecipes",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFavoriteRecipes_RecipeId",
                table: "UsersFavoriteRecipes",
                column: "RecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesRecipes");

            migrationBuilder.DropTable(
                name: "ShoppingListsRecipeIngredients");

            migrationBuilder.DropTable(
                name: "UsersFavoriteRecipes");

            migrationBuilder.CreateTable(
                name: "AppUserRecipe",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FavoriteRecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRecipe", x => new { x.AppUserId, x.FavoriteRecipesId });
                    table.ForeignKey(
                        name: "FK_AppUserRecipe_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppUserRecipe_Recipes_FavoriteRecipesId",
                        column: x => x.FavoriteRecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryRecipe",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    RecipesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipe", x => new { x.CategoriesId, x.RecipesId });
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CategoryRecipe_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredientShoppingList",
                columns: table => new
                {
                    RecipeIngredientsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredientShoppingList", x => new { x.RecipeIngredientsId, x.ShoppingListsId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredientShoppingList_RecipeIngredients_RecipeIngredientsId",
                        column: x => x.RecipeIngredientsId,
                        principalTable: "RecipeIngredients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecipeIngredientShoppingList_ShoppingLists_ShoppingListsId",
                        column: x => x.ShoppingListsId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRecipe_FavoriteRecipesId",
                table: "AppUserRecipe",
                column: "FavoriteRecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipe_RecipesId",
                table: "CategoryRecipe",
                column: "RecipesId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredientShoppingList_ShoppingListsId",
                table: "RecipeIngredientShoppingList",
                column: "ShoppingListsId");
        }
    }
}
