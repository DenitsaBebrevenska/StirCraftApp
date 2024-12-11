using System.ComponentModel.DataAnnotations.Schema;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents recipe ingredient entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class RecipeIngredient : BaseEntity
{
    /// <summary>
    /// The unique identifier of the ingredient
    /// </summary>
    [ForeignKey(nameof(Ingredient))]
    public int IngredientId { get; set; }

    /// <summary>
    /// A navigational property of the ingredient
    /// </summary>
    public virtual Ingredient Ingredient { get; set; } = null!;

    /// <summary>
    /// Quantity of the ingredient if any
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// The unique identifier of the measurement unit if any
    /// </summary>
    [ForeignKey(nameof(MeasurementUnit))]
    public int? MeasurementUnitId { get; set; }

    /// <summary>
    /// A navigational property to the measurement unit if any
    /// </summary>
    public virtual MeasurementUnit? MeasurementUnit { get; set; }

    /// <summary>
    /// The unique identifier of the recipe associated with this ingredient
    /// </summary>
    [ForeignKey(nameof(Recipe))]
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the recipe associated with this ingredient
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;


}
