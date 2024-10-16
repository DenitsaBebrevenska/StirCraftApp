using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Infrastructure.Identity;
using System.Text.Json;

namespace StirCraftApp.Infrastructure.Data.SeedData;
public static class SeedDataHelper
{
	private static readonly string BaseFolderPath =
		Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\StirCraftApp\StirCraftApp.Infrastructure\Data\SeedData\SeedJsons"));

	public static async Task SeedAllAsync(StirCraftDbContext context)
	{
		//Seed Roles
		await SeedTable("Roles", context.Roles);

		//Seed Users
		await SeedTable("Users", context.Users);

		//Attach users to roles
		await SeedTable("UsersRoles", context.UserRoles);

		//Seed Categories
		await SeedTable("Categories", context.Categories);

		//Seed Ingredients
		await SeedTable("Ingredients", context.Ingredients);

		//Seed Ranks
		await SeedTable("Ranks", context.CookingRanks);

		//Seed Units
		await SeedTable("Units", context.MeasurementUnits);

		//Seed Cooks
		await SeedTable("Cooks", context.Cooks);

		//Seed Recipes
		await SeedTable("Recipes", context.Recipes);

		//Seed RecipeRatings
		await SeedTable("RecipeRatings", context.RecipeRatings);

		//Seed RecipeImages
		await SeedTable("RecipeImages", context.RecipeImages);

		//Seed RecipeIngredients
		await SeedTable("RecipeIngredients", context.RecipeIngredients);

		//Seed UsersFavoriteRecipes
		await SeedTable("UsersFavoriteRecipes", context.UsersFavoriteRecipes);

		//Seed CategoriesRecipes
		await SeedTable("CategoriesRecipes", context.CategoriesRecipes);

		//Seed Comments
		await SeedTable("UsersRecipeComments", context.Comments);

		//Seed Replies
		await SeedTable("UsersCommentsReplies", context.Replies);

		//Seed ShoppingLists
		await SeedTable("ShoppingLists", context.ShoppingLists);

		//Seed ShoppingListsRecipeIngredients
		await SeedTable("ShoppingListsRecipeIngredients", context.ShoppingListsRecipeIngredients);

		//Save All changes if we`ve reached thus far
		await context.SaveChangesAsync();
	}

	private static async Task<List<T>> LoadJsonDataAsync<T>(string fileName) where T : class
	{
		var filePath = Path.Combine(BaseFolderPath, $"{fileName}.json");

		if (!File.Exists(filePath))
		{
			throw new ArgumentException($"File does not exist {filePath}");
		}

		var json = await File.ReadAllTextAsync(filePath);

		return JsonSerializer.Deserialize<List<T>>(json) ?? throw new NullReferenceException($"Failed to read {fileName}.json");
	}

	private static async Task SeedTable<T>(string fileName, DbSet<T> targetTable) where T : class
	{
		if (await targetTable.AnyAsync())
		{
			throw new ArgumentException($"{nameof(targetTable)} is seeded already.");
		}

		var entries = await LoadJsonDataAsync<T>(fileName);

		if (fileName == "Users")
		{
			SetTestUsersHashedPasswords((entries as List<AppUser>)!);
		}

		await targetTable.AddRangeAsync(entries);
	}

	private static void SetTestUsersHashedPasswords(List<AppUser> users)
	{
		var hasher = new PasswordHasher<AppUser>();

		for (var index = 1; index <= users.Count; index++)
		{
			var user = users[index - 1];
			user.PasswordHash = hasher.HashPassword(user, $"Test@{index}");
		}
	}
}
