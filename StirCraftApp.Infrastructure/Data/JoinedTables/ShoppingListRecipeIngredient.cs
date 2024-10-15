using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;
public class ShoppingListRecipeIngredient
{
	public int ShoppingListId { get; set; }

	public virtual required ShoppingList ShoppingList { get; set; }

	public int RecipeIngredientId { get; set; }

	public virtual required RecipeIngredient RecipeIngredient { get; set; }
}
