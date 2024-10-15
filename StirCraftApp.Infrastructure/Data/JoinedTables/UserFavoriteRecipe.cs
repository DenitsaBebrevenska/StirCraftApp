using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;
public class UserFavoriteRecipe
{
	public required string UserId { get; set; }

	[ForeignKey(nameof(UserId))]
	public virtual required AppUser AppUser { get; set; }

	public int RecipeId { get; set; }

	public virtual required Recipe Recipe { get; set; } = null!;
}
