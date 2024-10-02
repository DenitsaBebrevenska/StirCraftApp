using Microsoft.AspNetCore.Identity;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constraints.EntityConstraints;

namespace StirCraftApp.Infrastructure.Identity;
public class AppUser : IdentityUser, ISoftDeletable
{
	[MaxLength(ImageUrlMaxLength)]
	public string? AvatarUrl { get; set; }
	public virtual ICollection<Recipe> FavoriteRecipes { get; set; } = new List<Recipe>();

	public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();

	public virtual ICollection<RecipeRating> RecipesRatings { get; set; } = new List<RecipeRating>();
	public bool IsDeleted { get; set; }
	public DateTime? DeletedOnUtc { get; set; }
}
