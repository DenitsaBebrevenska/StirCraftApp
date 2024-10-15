using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;
using System.Text.Json;

namespace StirCraftApp.Infrastructure.Data.SeedData;
public static class SeedDataHelper
{
	private const string BaseFolderPath = "SeedData/SeedJsons";

	public static async Task SeedAllAsync(StirCraftDbContext context)
	{
		//what would be a good check if the db is seeded at all?
		if (await context.Recipes.AnyAsync())
		{
			return;
		}

		//Seed Users
		var users = await CreateTestUsersAsync();

		if (users != null)
		{
			await context.Users.AddRangeAsync(users);
		}

		//Seed Roles
		var roles = await LoadJsonDataAsync<IdentityRole>("Roles");

		if (roles != null)
		{
			await context.Roles.AddRangeAsync(roles);
		}

		//Attach users to roles
		var usersRoles = await LoadJsonDataAsync<IdentityUserClaim<string>>("UsersRoles");
		if (usersRoles != null)
		{
			await context.UserClaims.AddRangeAsync(usersRoles);
		}

		//Seed Categories
		var categories = await LoadJsonDataAsync<Category>("Categories");
		if (categories != null)
		{
			await context.Categories.AddRangeAsync(categories);
		}

		//Seed Ingredients
		var ingredients = await LoadJsonDataAsync<Ingredient>("Ingredients");
		if (ingredients != null)
		{
			await context.Ingredients.AddRangeAsync(ingredients);
		}

		//Seed Ranks
		var cookingRanks = await LoadJsonDataAsync<CookingRank>("Ranks");
		if (cookingRanks != null)
		{
			await context.CookingRanks.AddRangeAsync(cookingRanks);
		}

		//Seed Units
		var measurementUnits = await LoadJsonDataAsync<MeasurementUnit>("Units");
		if (measurementUnits != null)
		{
			await context.MeasurementUnits.AddRangeAsync(measurementUnits);
		}

		//Seed Recipes
		var recipes = await LoadJsonDataAsync<Recipe>("Recipes");
		if (recipes != null)
		{
			await context.Recipes.AddRangeAsync(recipes);
		}

	}

	private static async Task<List<T>?> LoadJsonDataAsync<T>(string fileName) where T : class
	{
		if (!File.Exists($"{BaseFolderPath}/{fileName}"))
		{
			return null;
		}

		var json = await File.ReadAllTextAsync($"{BaseFolderPath}/{fileName}");

		return JsonSerializer.Deserialize<List<T>>(json);
	}

	private static async Task<List<AppUser>?> CreateTestUsersAsync()
	{
		var hasher = new PasswordHasher<AppUser>();

		var users = await LoadJsonDataAsync<AppUser>($"{BaseFolderPath}/Users.json");

		if (users != null)
		{
			for (var index = 1; index <= users.Count; index++)
			{
				var user = users[index];
				user.PasswordHash = hasher.HashPassword(user, $"Test@{index}");
			}

			return users;
		}

		return null;
	}
}
