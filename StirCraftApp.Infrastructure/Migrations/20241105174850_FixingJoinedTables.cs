using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingJoinedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListsRecipeIngredients",
                table: "ShoppingListsRecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListsRecipeIngredients_RecipeIngredientId",
                table: "ShoppingListsRecipeIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesRecipes",
                table: "CategoriesRecipes");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesRecipes_RecipeId",
                table: "CategoriesRecipes");

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListsRecipeIngredients",
                table: "ShoppingListsRecipeIngredients",
                columns: new[] { "RecipeIngredientId", "ShoppingListId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesRecipes",
                table: "CategoriesRecipes",
                columns: new[] { "RecipeId", "CategoryId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5c1e9e8-6ae7-441e-b3c6-9021e37b3634", "AQAAAAIAAYagAAAAEBXTcCFUoNfw3nuNwEpqxdMQW8M+FTlZoA3GyFTnUKeaZycyVRLexLFVpC7tbo9lKA==", "0f70a0d3-63e7-44bd-92e6-4e1e07e2d32e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4ec3db3-bf2c-4ba0-93ea-d19d45af047c", "AQAAAAIAAYagAAAAEMzWEyAtt/DgW4zfisJycnqJoZw0xzgkUGGdnvfN5EKS3JW3AUQTChcZFlW6lu+BNQ==", "4c672ca3-015f-4871-b36a-0cfa60185807" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "323140e9-1e79-486e-a5c7-7bd9fb83eb60", "AQAAAAIAAYagAAAAEFPMv47kI5DpuXkT3AFhOnGJ/Hk6/KreXE/c4Gnrg4UXpD7oct0N2CiMib6VzMeu+g==", "99d007d9-28d8-4f1a-a7a7-e3099a6564fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c23f254a-88af-4e7d-ad79-d12239daafd8", "AQAAAAIAAYagAAAAEOVe0QU9QIPV70QLADru7IwGRQu7f+72ylWTTaujPn20jULQE223AmyqvL6UrBFjWw==", "f6cf8b37-7f10-43f9-bd42-1e01be7957a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b4bdbb0-85a2-47b7-aa0f-b8476566e0d4", "AQAAAAIAAYagAAAAEI5GvnL6CyeuICSISWh/wSOfWNJKW5NqfTBPfuRuRlZTW43Wyfz+ru0Twi4guXb7VQ==", "530ed271-3876-4d66-a44d-bd7680a255b4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc08702-ca06-44ad-bd31-584fb4b0fc35", "AQAAAAIAAYagAAAAEPztByBtQUCTw30ma+FafLK1DD+ZkYFQHFYKt7weQUIfhUVQl6wQm9wVBpV66yH2QQ==", "58ba1580-33ce-4104-bce0-a058919ef777" });

            migrationBuilder.InsertData(
                table: "CategoriesRecipes",
                columns: new[] { "CategoryId", "RecipeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 8, 1 },
                    { 6, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 16, 3 },
                    { 16, 4 },
                    { 18, 4 },
                    { 21, 5 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListsRecipeIngredients",
                columns: new[] { "RecipeIngredientId", "ShoppingListId" },
                values: new object[,]
                {
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 2 },
                    { 17, 2 },
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListsRecipeIngredients_ShoppingListId",
                table: "ShoppingListsRecipeIngredients",
                column: "ShoppingListId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesRecipes_CategoryId",
                table: "CategoriesRecipes",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingListsRecipeIngredients",
                table: "ShoppingListsRecipeIngredients");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingListsRecipeIngredients_ShoppingListId",
                table: "ShoppingListsRecipeIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoriesRecipes",
                table: "CategoriesRecipes");

            migrationBuilder.DropIndex(
                name: "IX_CategoriesRecipes_CategoryId",
                table: "CategoriesRecipes");

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 16, 4 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "CategoriesRecipes",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { 21, 5 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 20, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 23, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 24, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingListsRecipeIngredients",
                keyColumns: new[] { "RecipeIngredientId", "ShoppingListId" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingListsRecipeIngredients",
                table: "ShoppingListsRecipeIngredients",
                columns: new[] { "ShoppingListId", "RecipeIngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoriesRecipes",
                table: "CategoriesRecipes",
                columns: new[] { "CategoryId", "RecipeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "980b1ab4-0559-4bc5-90c2-cb4c1083550f", "AQAAAAIAAYagAAAAEECYOQq4Xh1Gt7xjKEThMg0gaDiAzOWDEjFLsrHqIjCJZOjTMw2kWVjgyRtaa0PoAg==", "cff70599-3fe9-4a24-84e4-e0f61e39394f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3326b1e8-de80-45c6-be0f-c987c7d4a079", "AQAAAAIAAYagAAAAELGYoWJ/UA+vaCqp4GGvQts/BfUxE6r51As5xRMldNXnWo1t//uOaYe+NNbyp2EK9Q==", "31dee186-c743-4324-bb9c-e001e6f641ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "82c69f54-2890-45af-a9ee-196750772930", "AQAAAAIAAYagAAAAEOkIpAmsNU6tdExMpolySWe8+0Sjo7JB3kYnB8FrftgGZiX3D/0+ir27Zr/fUBk9Nw==", "57a327ea-bf02-441a-896e-4dda032373bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1d0a9bb-ee12-4b8d-a8ea-cb910f73bb7e", "AQAAAAIAAYagAAAAEM781he74Lf9I5TnDp3i31tkfNakbAcz0X9P14W9gV/iUYkrrg0szU5jEhRhGntY9w==", "c44ebe42-dac6-4b3e-b97f-0506e842b2f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e7b8ca2-4e05-4a7e-9088-d48d8569f16c", "AQAAAAIAAYagAAAAEIl10MC1UYMs+SNijZi5aBY/1bFZo5vAvyHNBku/+wSCpXpuD+J47u3mUNFCqzAmtQ==", "9c248072-a271-492c-a514-a6c3cc26209e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcda0eec-37b5-4651-93cf-76a68e5d598e", "AQAAAAIAAYagAAAAEAOEkkIjvAcegtAE+k82S/HIxCWeJJrENzZgYV57DZGbpW8cPIJrWYFtgdQiRNQ+vA==", "f76eb20c-4e12-4ce6-9243-721a555cf832" });

            migrationBuilder.InsertData(
                table: "CategoriesRecipes",
                columns: new[] { "CategoryId", "RecipeId" },
                values: new object[,]
                {
                    { 4, 1 },
                    { 6, 2 },
                    { 8, 1 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 3 },
                    { 16, 3 },
                    { 16, 4 },
                    { 18, 4 },
                    { 21, 5 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingListsRecipeIngredients",
                columns: new[] { "RecipeIngredientId", "ShoppingListId" },
                values: new object[,]
                {
                    { 18, 1 },
                    { 19, 1 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 23, 1 },
                    { 24, 1 },
                    { 25, 1 },
                    { 26, 1 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 10, 2 },
                    { 11, 2 },
                    { 12, 2 },
                    { 13, 2 },
                    { 14, 2 },
                    { 15, 2 },
                    { 16, 2 },
                    { 17, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListsRecipeIngredients_RecipeIngredientId",
                table: "ShoppingListsRecipeIngredients",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesRecipes_RecipeId",
                table: "CategoriesRecipes",
                column: "RecipeId");
        }
    }
}
