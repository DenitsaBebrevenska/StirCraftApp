using Microsoft.EntityFrameworkCore;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Infrastructure.Data.JoinedTables;

[PrimaryKey(nameof(ShoppingListId), nameof(RecipeIngredientId))]
public class ShoppingListRecipeIngredient
{
	public int ShoppingListId { get; set; }
	public virtual ShoppingList ShoppingList { get; set; } = null!;

	public int RecipeIngredientId { get; set; }

	public virtual RecipeIngredient RecipeIngredient { get; set; } = null!;
}
