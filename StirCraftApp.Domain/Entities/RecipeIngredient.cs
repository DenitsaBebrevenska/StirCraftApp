using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Domain.Entities;
public class RecipeIngredient : BaseEntity
{
    [ForeignKey(nameof(Ingredient))]
    public int IngredientId { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public uint? Quantity { get; set; }

    [ForeignKey(nameof(MeasurementUnit))]
    public int? MeasurementUnitId { get; set; }

    public virtual MeasurementUnit? MeasurementUnit { get; set; }

    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;


}
