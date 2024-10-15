namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
	public int IngredientId { get; set; }

	public virtual required Ingredient Ingredient { get; set; }

	public uint? Quantity { get; set; }

	public int? MeasurementUnitId { get; set; }

	public virtual MeasurementUnit? MeasurementUnit { get; set; }

	public int RecipeId { get; set; }

	public virtual required Recipe Recipe { get; set; }

}
