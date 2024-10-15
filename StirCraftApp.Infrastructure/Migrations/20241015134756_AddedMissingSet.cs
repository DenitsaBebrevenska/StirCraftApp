using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedMissingSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientShoppingList_ShoppingList_ShoppingListsId",
                table: "RecipeIngredientShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_AspNetUsers_UserId",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                newName: "ShoppingLists");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingList_UserId",
                table: "ShoppingLists",
                newName: "IX_ShoppingLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingList_IsDeleted",
                table: "ShoppingLists",
                newName: "IX_ShoppingLists_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientShoppingList_ShoppingLists_ShoppingListsId",
                table: "RecipeIngredientShoppingList",
                column: "ShoppingListsId",
                principalTable: "ShoppingLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredientShoppingList_ShoppingLists_ShoppingListsId",
                table: "RecipeIngredientShoppingList");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_AspNetUsers_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                newName: "ShoppingList");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingList",
                newName: "IX_ShoppingList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingLists_IsDeleted",
                table: "ShoppingList",
                newName: "IX_ShoppingList_IsDeleted");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredientShoppingList_ShoppingList_ShoppingListsId",
                table: "RecipeIngredientShoppingList",
                column: "ShoppingListsId",
                principalTable: "ShoppingList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_AspNetUsers_UserId",
                table: "ShoppingList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
