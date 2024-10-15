using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Infrastructure.Identity;
using System.Text.Json;

namespace StirCraftApp.Infrastructure.Data.SeedData;
public static class SeedDataHelper
{
	private const string BaseFolderPath = "SeedData/SeedJsons";

	public static async Task SeedAllAsync(StirCraftDbContext context)
	{
		//what would be a good check if the db is seeded at all?
		if (await context.Users.AnyAsync())
		{
			return;
		}

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
		await SeedTable("Comments", context.Comments);

		//Seed Replies
		await SeedTable("Replies", context.Replies);

		//Seed ShoppingLists
		await SeedTable("ShoppingLists", context.ShoppingLists);

		//Seed ShoppingListsRecipeIngredients
		await SeedTable("ShoppingListsRecipeIngredients", context.ShoppingListsRecipeIngredients);
	}

	private static async Task<List<T>> LoadJsonDataAsync<T>(string fileName) where T : class
	{
		if (!File.Exists($"{BaseFolderPath}/{fileName}"))
		{
			throw new ArgumentException($"File does not exist {BaseFolderPath}/{fileName}");
		}

		var json = await File.ReadAllTextAsync($"{BaseFolderPath}/{fileName}");

		return JsonSerializer.Deserialize<List<T>>(json) ?? throw new NullReferenceException($"Failed to read {fileName}.json");
	}

	private static async Task SeedTable<T>(string fileName, DbSet<T> targetTable) where T : class
	{
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
			var user = users[index];
			user.PasswordHash = hasher.HashPassword(user, $"Test@{index}");
		}
	}
}
