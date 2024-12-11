using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents an ingredient entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Ingredient : BaseEntity
{
    /// <summary>
    /// The name of the ingredient
    /// </summary>
    [MaxLength(IngredientNameMaxLength)]
    public required string Name { get; set; }

    /// <summary>
    /// A flag indicating if the ingredient is an allergen
    /// </summary>
    public bool IsAllergen { get; set; }

    /// <summary>
    /// A flag indicating if the ingredient is approved by an admin
    /// </summary>
    public bool IsAdminApproved { get; set; }

    /// <summary>
    /// A collection of all recipe ingredients in which that ingredient takes part in 
    /// </summary>
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
}
