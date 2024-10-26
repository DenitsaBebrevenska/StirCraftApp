using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StirCraftApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", null, "Cook", "COOK" },
                    { "eec0c147-bcdc-49f0-aadc-9b2d906ee763", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "DeletedOnUtc", "DisplayName", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a575c2a-065c-487a-8b56-cfd897b1b5ce", 0, "https://plus.unsplash.com/premium_photo-1661778091956-15dbe6e47442?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "980b1ab4-0559-4bc5-90c2-cb4c1083550f", null, "ThePowerOfMorgoth", "galadriel@example.com", false, false, false, null, "GALADRIEL@EXAMPLE.COM", "GALADRIEL@EXAMPLE.COM", "AQAAAAIAAYagAAAAEECYOQq4Xh1Gt7xjKEThMg0gaDiAzOWDEjFLsrHqIjCJZOjTMw2kWVjgyRtaa0PoAg==", null, false, "cff70599-3fe9-4a24-84e4-e0f61e39394f", false, "galadriel@example.com" },
                    { "3b3c303f-b227-48d8-a30d-1932e90b058a", 0, "https://plus.unsplash.com/premium_photo-1658506818080-0546c7636830?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "3326b1e8-de80-45c6-be0f-c987c7d4a079", null, "LoveLink", "zelda@example.com", false, false, false, null, "ZELDA@EXAMPLE.COM", "ZELDA@EXAMPLE.COM", "AQAAAAIAAYagAAAAELGYoWJ/UA+vaCqp4GGvQts/BfUxE6r51As5xRMldNXnWo1t//uOaYe+NNbyp2EK9Q==", null, false, "31dee186-c743-4324-bb9c-e001e6f641ec", false, "zelda@example.com" },
                    { "6d362fcc-dc94-4385-8b38-844527a2c579", 0, null, "82c69f54-2890-45af-a9ee-196750772930", null, "StirCraftAdmin", "admin@example.com", false, false, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEOkIpAmsNU6tdExMpolySWe8+0Sjo7JB3kYnB8FrftgGZiX3D/0+ir27Zr/fUBk9Nw==", null, false, "57a327ea-bf02-441a-896e-4dda032373bb", false, "admin@example.com" },
                    { "98f61b51-9ae7-4107-a247-29d1c68a7d32", 0, "https://plus.unsplash.com/premium_photo-1673830185832-2d5f30a900ed?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "d1d0a9bb-ee12-4b8d-a8ea-cb910f73bb7e", null, "AdrianTheAdventurer", "adrian@example.com", false, false, false, null, "ADRIAN@EXAMPLE.COM", "ADRIAN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEM781he74Lf9I5TnDp3i31tkfNakbAcz0X9P14W9gV/iUYkrrg0szU5jEhRhGntY9w==", null, false, "c44ebe42-dac6-4b3e-b97f-0506e842b2f0", false, "adrian@example.com" },
                    { "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 0, "https://plus.unsplash.com/premium_photo-1661768360749-b60196445a6d?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "7e7b8ca2-4e05-4a7e-9088-d48d8569f16c", null, "KateMiddleton", "kate@example.com", false, false, false, null, "KATE@EXAMPLE.COM", "KATE@EXAMPLE.COM", "AQAAAAIAAYagAAAAEIl10MC1UYMs+SNijZi5aBY/1bFZo5vAvyHNBku/+wSCpXpuD+J47u3mUNFCqzAmtQ==", null, false, "9c248072-a271-492c-a514-a6c3cc26209e", false, "kate@example.com" },
                    { "f44c3f06-172b-491e-b71d-8672ac7595cb", 0, "https://plus.unsplash.com/premium_photo-1677852512190-5a89ee399aed?q=80&w=1887&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", "dcda0eec-37b5-4651-93cf-76a68e5d598e", null, "ChefBob", "bob@example.com", false, false, false, null, "BOB@EXAMPLE.COM", "BOB@EXAMPLE.COM", "AQAAAAIAAYagAAAAEAOEkkIjvAcegtAE+k82S/HIxCWeJJrENzZgYV57DZGbpW8cPIJrWYFtgdQiRNQ+vA==", null, false, "f76eb20c-4e12-4ce6-9243-721a555cf832", false, "bob@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, null, false, "Asian Cuisine" },
                    { 2, null, false, "Dessert" },
                    { 3, null, false, "Amuse Bouche" },
                    { 4, null, false, "Italian Cuisine" },
                    { 5, null, false, "Grill & Barbecue" },
                    { 6, null, false, "Salads" },
                    { 7, null, false, "Seafood" },
                    { 8, null, false, "Pasta" },
                    { 9, null, false, "Vegetarian" },
                    { 10, null, false, "Vegan" },
                    { 11, null, false, "Breakfast" },
                    { 12, null, false, "Soups & Stews" },
                    { 13, null, false, "Snacks" },
                    { 14, null, false, "Beverages" },
                    { 15, null, false, "Appetizers" },
                    { 16, null, false, "Comfort Food" },
                    { 17, null, false, "French Cuisine" },
                    { 18, null, false, "Mexican Cuisine" },
                    { 19, null, false, "Mediterranean Cuisine" },
                    { 20, null, false, "Baking & Pastries" },
                    { 21, null, false, "Russian Cuisine" }
                });

            migrationBuilder.InsertData(
                table: "CookingRanks",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RequiredPoints", "Title" },
                values: new object[,]
                {
                    { 1, null, false, 0L, "StirCraftNovice" },
                    { 2, null, false, 500L, "StirSpecialist" },
                    { 3, null, false, 1000L, "FlavorOperative" },
                    { 4, null, false, 1500L, "SeasonedCommander" },
                    { 5, null, false, 2000L, "MasterOfStirCraft" },
                    { 6, null, false, 3000L, "CulinaryOverlord" },
                    { 7, null, false, 5000L, "StirCraftGod" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "DeletedOnUtc", "IsAllergen", "IsDeleted", "IsSolid", "Name", "NameInPlural" },
                values: new object[,]
                {
                    { 1, null, false, false, true, "flour", null },
                    { 2, null, true, false, true, "egg", "eggs" },
                    { 3, null, false, false, true, "sugar", null },
                    { 4, null, true, false, false, "milk", null },
                    { 5, null, false, false, true, "salt", null },
                    { 6, null, true, false, true, "butter", null },
                    { 7, null, false, false, false, "olive oil", null },
                    { 8, null, false, false, true, "tomato", "tomatoes" },
                    { 9, null, false, false, true, "garlic", null },
                    { 10, null, false, false, true, "onion", "onions" },
                    { 11, null, false, false, true, "chicken breast", "chicken breasts" },
                    { 12, null, false, false, true, "ground beef", null },
                    { 13, null, false, false, true, "carrot", "carrots" },
                    { 14, null, true, false, true, "celery", "celeries" },
                    { 15, null, true, false, true, "almond", "almonds" },
                    { 16, null, true, false, true, "peanut", "peanuts" },
                    { 17, null, true, false, false, "soy sauce", null },
                    { 18, null, false, false, true, "lemon", "lemons" },
                    { 19, null, false, false, true, "lime", "limes" },
                    { 20, null, false, false, true, "basil", null },
                    { 21, null, false, false, true, "parsley", null },
                    { 22, null, false, false, true, "mushroom", "mushrooms" },
                    { 23, null, false, false, true, "spinach", null },
                    { 24, null, false, false, false, "coconut milk", null },
                    { 25, null, true, false, true, "shrimp", "shrimps" },
                    { 26, null, false, false, true, "salmon", "salmons" },
                    { 27, null, false, false, true, "tofu", null },
                    { 28, null, false, false, true, "chickpeas", null },
                    { 29, null, false, false, true, "potato", "potatoes" },
                    { 30, null, false, false, true, "rice", null },
                    { 31, null, false, false, true, "pasta", null },
                    { 32, null, false, false, true, "broccoli", null },
                    { 33, null, false, false, true, "cauliflower", null },
                    { 34, null, false, false, true, "green beans", null },
                    { 35, null, false, false, true, "zucchini", "zucchinis" },
                    { 36, null, false, false, true, "corn", "corns" },
                    { 37, null, true, false, true, "cheese", null },
                    { 38, null, true, false, true, "cream", null },
                    { 39, null, true, false, true, "yogurt", null },
                    { 40, null, false, false, false, "honey", null },
                    { 41, null, false, false, false, "maple syrup", null },
                    { 42, null, false, false, true, "baking powder", null },
                    { 43, null, false, false, true, "yeast", null },
                    { 44, null, false, false, true, "cinnamon", null },
                    { 45, null, false, false, true, "cumin", null },
                    { 46, null, false, false, true, "ginger", null },
                    { 47, null, false, false, false, "vanilla extract", null },
                    { 48, null, false, false, true, "black pepper", null },
                    { 49, null, false, false, true, "oregano", null },
                    { 50, null, false, false, true, "paprika", null },
                    { 51, null, true, false, true, "spaghetti", null },
                    { 52, null, false, false, true, "chili flakes", null },
                    { 53, null, false, false, true, "chili powder", null },
                    { 54, null, false, false, true, "quinoa", null },
                    { 55, null, false, false, true, "cucumber", "cucumbers" },
                    { 56, null, false, false, true, "cherry tomato", "cherry tomatoes" },
                    { 57, null, false, false, true, "red onion", "red onions" },
                    { 58, null, false, false, true, "avocado", "avocadoes" },
                    { 59, null, true, false, true, "tahini", null },
                    { 60, null, false, false, true, "cilantro", null },
                    { 61, null, true, false, true, "almond flour", null },
                    { 62, null, true, false, true, "berries mix", null },
                    { 63, null, true, false, true, "taco shell", "taco shells" },
                    { 64, null, true, false, true, "tortilla", "tortillas" },
                    { 65, null, true, false, true, "egg noodles", null },
                    { 66, null, true, false, true, "mustard", null },
                    { 67, null, true, false, false, "Worcestershire sauce", null },
                    { 68, null, true, false, true, "sour cream", null },
                    { 69, null, false, false, true, "jalapeño", "jalapeños" },
                    { 70, null, false, false, true, "beef", null }
                });

            migrationBuilder.InsertData(
                table: "MeasurementUnits",
                columns: new[] { "Id", "Abbreviation", "DeletedOnUtc", "IsDeleted", "IsLiquidSpecific", "IsSolidSpecific", "Name" },
                values: new object[,]
                {
                    { 1, "g", null, false, false, true, "Gram" },
                    { 2, "kg", null, false, false, true, "Kilogram" },
                    { 3, "mg", null, false, false, true, "Milligram" },
                    { 4, "oz", null, false, false, true, "Ounce" },
                    { 5, "lb", null, false, false, true, "Pound" },
                    { 6, "L", null, false, true, false, "Liter" },
                    { 7, "mL", null, false, true, false, "Milliliter" },
                    { 8, "tsp", null, false, false, false, "Teaspoon" },
                    { 9, "tbsp", null, false, false, false, "Tablespoon" },
                    { 10, "cup", null, false, false, false, "Cup" },
                    { 11, "fl oz", null, false, true, false, "Fluid Ounce" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "1a575c2a-065c-487a-8b56-cfd897b1b5ce" },
                    { "eec0c147-bcdc-49f0-aadc-9b2d906ee763", "6d362fcc-dc94-4385-8b38-844527a2c579" },
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "98f61b51-9ae7-4107-a247-29d1c68a7d32" },
                    { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "f44c3f06-172b-491e-b71d-8672ac7595cb" }
                });

            migrationBuilder.InsertData(
                table: "Cooks",
                columns: new[] { "Id", "About", "CookingRankId", "DeletedOnUtc", "IsDeleted", "RankingPoints", "UserId" },
                values: new object[,]
                {
                    { 1, "I am a home cook with love for classic comfort foods. I often experiment with traditional recipes, adding my personal twist to create something familiar yet unique.", 1, null, false, 10L, "f44c3f06-172b-491e-b71d-8672ac7595cb" },
                    { 2, "Inspired by my travels, I enjoy combining fresh, vibrant ingredients like olive oil, herbs, and seafood to create dishes that are both healthy and full of flavor. My philosophy in cooking revolves around simplicity. I love the Mediterranean Cuisine.", 3, null, false, 1200L, "98f61b51-9ae7-4107-a247-29d1c68a7d32" },
                    { 3, "I am passionate about modern fusion cuisine, blending flavors and techniques from around the world. I think of myself as quite innovative in the use of seasonal ingredients and attention to detail, making every meal an unforgettable experience. Also I excel at Asian cuisine, you can call me Senpai!", 5, null, false, 2200L, "1a575c2a-065c-487a-8b56-cfd897b1b5ce" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, false, "Favorite pancakes", "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 2, null, false, "Quinoa Salad NOM NOM", "3b3c303f-b227-48d8-a30d-1932e90b058a" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AdminNotes", "CookId", "CreatedOn", "DeletedOnUtc", "DifficultyLevel", "IsAdminApproved", "IsDeleted", "Name", "PreparationSteps", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, 2, new DateTime(2024, 10, 6, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true, false, "Spaghetti Aglio e Olio", "Cook the spaghetti in salted boiling water until al dente. Reserve some pasta water before draining. Heat olive oil in a pan over medium heat, then add thinly sliced garlic and chili flakes. Sauté until fragrant but not browned.Add the cooked spaghetti to the pan and toss with the garlic oil. Add reserved pasta water to loosen the sauce if needed. Season with salt and pepper to taste, garnish with fresh parsley, and serve.", new DateTime(2024, 10, 6, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, 2, new DateTime(2024, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Quinoa Salad", "Cook quinoa in water (you can use vegetable broth if you like). Let it cool. In a large bowl, combine diced cucumber, cherry tomatoes, red onion, and avocado. Add the cooled quinoa and mix well. In a small bowl, whisk together lemon juice, olive oil, tahini, salt, and pepper. Pour the dressing over the salad and toss. Garnish with fresh herbs like parsley and cilantro and serve chilled.", new DateTime(2024, 9, 15, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, 3, new DateTime(2024, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Gluten-Free Almond Pancakes", "In a bowl, whisk together almond flour, eggs, baking powder, vanilla extract, and a pinch of salt until smooth. Heat a non-stick pan over medium heat and grease lightly with butter. Pour small amounts of batter onto the pan and cook until bubbles form on the surface, then flip and cook the other side until golden brown. Serve pancakes with fresh berries, maple syrup, and a sprinkle of almond slices for garnish.", new DateTime(2024, 8, 22, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, 1, new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true, false, "Spicy Chicken Tacos", "Marinate chicken breast in a mixture of chili powder, cumin, paprika, garlic, lime juice, and olive oil for at least 30 minutes. Cook the marinated chicken in a pan over medium heat until fully cooked and slightly charred. Warm the taco shells in the oven or on a pan. Assemble the tacos by adding chicken, finely chopped ripe tomatoes, onion, cilantro, jalapeño, and lime, and avocado.", new DateTime(2024, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, 3, new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), null, 3, true, false, "Classic Beef Stroganoff", "Cook egg noodles according to package instructions, drain, and set aside. In a large pan, brown strips of beef in butter over high heat. Remove from the pan and set aside. In the same pan, sauté onions and mushrooms until softened. Add garlic and cook for another minute. Stir in beef broth, mustard, and Worcestershire sauce, then return the beef to the pan. Reduce heat, stir in sour cream, and simmer until the sauce thickens. Serve the beef stroganoff over egg noodles, garnished with fresh parsley.", new DateTime(2024, 6, 5, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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
                table: "Comments",
                columns: new[] { "Id", "Body", "DeletedOnUtc", "IsDeleted", "RecipeId", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "My grandchildren love these pancakes! They are a very good choice for a healthy breakfast!", null, false, 3, "Fabulous!", "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 2, "So delicious, yet so healthy!", null, false, 2, "Awesome salad", "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 3, "I really need help. How long should I cook the beef strips for? I`m afraid they`ll end up raw...", null, false, 5, "Need help!", "3b3c303f-b227-48d8-a30d-1932e90b058a" }
                });

            migrationBuilder.InsertData(
                table: "RecipeImages",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RecipeId", "Url" },
                values: new object[,]
                {
                    { 1, null, false, 1, "https://images.unsplash.com/photo-1562281556-0f8c259a9f3a?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 2, null, false, 2, "https://plus.unsplash.com/premium_photo-1704989936092-c41f477cb6e2?q=80&w=2071&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 3, null, false, 3, "https://images.unsplash.com/photo-1522248105696-9625ba87de6e?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 4, null, false, 4, "https://images.unsplash.com/photo-1596078841464-028efe9ddced?q=80&w=1964&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D" },
                    { 5, null, false, 5, "https://media.istockphoto.com/id/817313114/photo/mushroom-beef-stroganoff-in-pan-with-copy-space.jpg?s=2048x2048&w=is&k=20&c=X6NMh7o18JfGseHdb1UwOzHWxpwC7kpwEDsJcvDrAms=" }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "Id", "DeletedOnUtc", "IngredientId", "IsDeleted", "MeasurementUnitId", "Quantity", "RecipeId" },
                values: new object[,]
                {
                    { 1, null, 51, false, 1, 500L, 1 },
                    { 2, null, 7, false, 9, 2L, 1 },
                    { 3, null, 9, false, null, null, 1 },
                    { 4, null, 52, false, 8, 1L, 1 },
                    { 5, null, 5, false, null, null, 1 },
                    { 6, null, 48, false, null, null, 1 },
                    { 7, null, 54, false, 1, 250L, 2 },
                    { 8, null, 55, false, null, 1L, 2 },
                    { 9, null, 56, false, null, 5L, 2 },
                    { 10, null, 57, false, null, 1L, 2 },
                    { 11, null, 58, false, null, 1L, 2 },
                    { 12, null, 18, false, null, null, 2 },
                    { 13, null, 7, false, 9, 2L, 2 },
                    { 14, null, 59, false, 9, 1L, 2 },
                    { 15, null, 5, false, null, null, 2 },
                    { 16, null, 48, false, null, null, 2 },
                    { 17, null, 21, false, null, null, 2 },
                    { 18, null, 60, false, null, null, 2 },
                    { 19, null, 61, false, 1, 200L, 3 },
                    { 20, null, 2, false, null, 2L, 3 },
                    { 21, null, 42, false, 8, 1L, 3 },
                    { 22, null, 47, false, null, null, 3 },
                    { 23, null, 5, false, null, null, 3 },
                    { 24, null, 6, false, null, null, 3 },
                    { 25, null, 62, false, null, null, 3 },
                    { 26, null, 41, false, null, null, 3 },
                    { 27, null, 15, false, null, null, 3 },
                    { 28, null, 11, false, 1, 500L, 4 },
                    { 29, null, 63, false, null, 4L, 4 },
                    { 30, null, 8, false, null, 2L, 4 },
                    { 31, null, 9, false, null, 1L, 4 },
                    { 32, null, 19, false, null, 1L, 4 },
                    { 33, null, 10, false, null, 1L, 4 },
                    { 34, null, 58, false, null, 1L, 4 },
                    { 35, null, 60, false, null, null, 4 },
                    { 36, null, 69, false, null, null, 4 },
                    { 37, null, 53, false, null, null, 4 },
                    { 38, null, 45, false, null, null, 4 },
                    { 39, null, 50, false, null, null, 4 },
                    { 40, null, 7, false, 8, 2L, 4 },
                    { 41, null, 65, false, 1, 200L, 5 },
                    { 42, null, 70, false, 1, 300L, 5 },
                    { 43, null, 10, false, null, 2L, 5 },
                    { 44, null, 22, false, 1, 250L, 5 },
                    { 45, null, 9, false, null, null, 5 },
                    { 46, null, 66, false, 8, 2L, 5 },
                    { 47, null, 67, false, 8, 1L, 5 },
                    { 48, null, 68, false, 1, 100L, 5 },
                    { 49, null, 21, false, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRatings",
                columns: new[] { "Id", "DeletedOnUtc", "IsDeleted", "RecipeId", "UserId", "Value" },
                values: new object[,]
                {
                    { 1, null, false, 3, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 5 },
                    { 2, null, false, 2, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 4 },
                    { 3, null, false, 5, "edc8a753-f0dc-483f-bbaf-d26dc2827d54", 5 },
                    { 4, null, false, 1, "3b3c303f-b227-48d8-a30d-1932e90b058a", 5 },
                    { 5, null, false, 4, "f44c3f06-172b-491e-b71d-8672ac7595cb", 5 }
                });

            migrationBuilder.InsertData(
                table: "UsersFavoriteRecipes",
                columns: new[] { "RecipeId", "UserId" },
                values: new object[,]
                {
                    { 1, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 2, "3b3c303f-b227-48d8-a30d-1932e90b058a" },
                    { 2, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 3, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" },
                    { 5, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" }
                });

            migrationBuilder.InsertData(
                table: "Replies",
                columns: new[] { "Id", "Body", "CommentId", "DeletedOnUtc", "IsDeleted", "UserId" },
                values: new object[,]
                {
                    { 1, "Generally the beef strips need to be seared, not completely cooked so anything between 3 to 5 minutes at max heat.", 3, null, false, "1a575c2a-065c-487a-8b56-cfd897b1b5ce" },
                    { 2, "Thank you! :)", 3, null, false, "3b3c303f-b227-48d8-a30d-1932e90b058a" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "1a575c2a-065c-487a-8b56-cfd897b1b5ce" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eec0c147-bcdc-49f0-aadc-9b2d906ee763", "6d362fcc-dc94-4385-8b38-844527a2c579" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "98f61b51-9ae7-4107-a247-29d1c68a7d32" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c63bad56-e374-4a01-ac1a-f49231cd1e2f", "f44c3f06-172b-491e-b71d-8672ac7595cb" });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);

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
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RecipeImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "RecipeRatings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RecipeRatings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RecipeRatings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RecipeRatings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipeRatings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Replies",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "UsersFavoriteRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 1, "3b3c303f-b227-48d8-a30d-1932e90b058a" });

            migrationBuilder.DeleteData(
                table: "UsersFavoriteRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 2, "3b3c303f-b227-48d8-a30d-1932e90b058a" });

            migrationBuilder.DeleteData(
                table: "UsersFavoriteRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 2, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" });

            migrationBuilder.DeleteData(
                table: "UsersFavoriteRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 3, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" });

            migrationBuilder.DeleteData(
                table: "UsersFavoriteRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 5, "edc8a753-f0dc-483f-bbaf-d26dc2827d54" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c63bad56-e374-4a01-ac1a-f49231cd1e2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eec0c147-bcdc-49f0-aadc-9b2d906ee763");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d362fcc-dc94-4385-8b38-844527a2c579");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b3c303f-b227-48d8-a30d-1932e90b058a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "edc8a753-f0dc-483f-bbaf-d26dc2827d54");

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MeasurementUnits",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f44c3f06-172b-491e-b71d-8672ac7595cb");

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cooks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a575c2a-065c-487a-8b56-cfd897b1b5ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98f61b51-9ae7-4107-a247-29d1c68a7d32");

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CookingRanks",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
