using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Identity;
public class AppUser : IdentityUser
{
	public string? AvatarUrl { get; set; }

	public virtual ICollection<Recipe> FavoriteRecipes { get; set; } = new List<Recipe>();

	public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

	public virtual ICollection<RecipeRating> RecipesRatings { get; set; } = new List<RecipeRating>();
}
