using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Infrastructure.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;

[PrimaryKey(nameof(UserId), nameof(RecipeId))]
public class UserFavoriteRecipe
{
	public required string UserId { get; set; }

	[ForeignKey(nameof(UserId))]
	public virtual AppUser AppUser { get; set; } = null!;

	public int RecipeId { get; set; }

	public virtual Recipe Recipe { get; set; } = null!;
}
