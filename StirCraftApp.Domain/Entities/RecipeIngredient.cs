namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
	public int IngredientId { get; set; }

	public uint Quantity { get; set; }

	public MeasurementUnit? MeasurementUnit { get; set; }

	public int RecipeId { get; set; }
}
