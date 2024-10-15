namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
	public int IngredientId { get; set; }

	public uint? Quantity { get; set; }

	public int? MeasurementUnitId { get; set; }

	public int RecipeId { get; set; }

	public virtual ICollection<ShoppingList> ShoppingLists { get; set; } = new List<ShoppingList>();
}
