using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a measurement unit entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class MeasurementUnit : BaseEntity
{
    /// <summary>
    /// The name of the measurement unit
    /// </summary>
    [MaxLength(UnitNameMaxLength)]
    public required string Name { get; set; }

    /// <summary>
    /// The abbreviation of the measurement unit`s name
    /// </summary>
    [MaxLength(UnitAbbreviationMaxLength)]
    public required string Abbreviation { get; set; }

    /// <summary>
    /// A collection of all recipe ingredients where the measurement unit takes part in 
    /// </summary>
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
