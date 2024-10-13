namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
	public int IngredientId { get; set; }

	public uint Quantity { get; set; }

	public int? MeasurementUnitId { get; set; }

	public int RecipeId { get; set; }

	public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

	public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
