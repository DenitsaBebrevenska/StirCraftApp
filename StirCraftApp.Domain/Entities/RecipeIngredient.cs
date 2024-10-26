namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
    public int IngredientId { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public uint? Quantity { get; set; }

    public int? MeasurementUnitId { get; set; }

    public virtual MeasurementUnit? MeasurementUnit { get; set; }

    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

}
