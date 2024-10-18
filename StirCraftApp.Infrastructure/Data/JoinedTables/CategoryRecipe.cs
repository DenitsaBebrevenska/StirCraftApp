using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;

[PrimaryKey(nameof(CategoryId), nameof(RecipeId))]
public class CategoryRecipe
{
	public int CategoryId { get; set; }

	public virtual Category Category { get; set; } = null!;

	public int RecipeId { get; set; }

	public virtual Recipe Recipe { get; set; } = null!;
}
