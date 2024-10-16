using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;
public class ShoppingListRecipeIngredient
{
	public int ShoppingListId { get; set; }
	public virtual ShoppingList ShoppingList { get; set; } = null!;

	public int RecipeIngredientId { get; set; }

	public virtual RecipeIngredient RecipeIngredient { get; set; } = null!;
}
