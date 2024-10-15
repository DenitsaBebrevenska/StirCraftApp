using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;
public class CategoryRecipe
{
	public int CategoryId { get; set; }

	public virtual required Category Category { get; set; }

	public int RecipeId { get; set; }

	public virtual required Recipe Recipe { get; set; }
}
