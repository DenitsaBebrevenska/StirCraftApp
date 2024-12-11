using StirCraftApp.Domain.JoinedTables;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;

namespace StirCraftApp.Domain.Entities;

/// <summary>
/// Represents a category entity
/// Inherits from BaseEntity therefor has unique identifier ID int, a soft-delete flag and a soft-delete datetime
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// The name of the category
    /// </summary>
    [MaxLength(CategoryMaxLength)]
    public required string Name { get; set; }

    /// <summary>
    /// A collection of recipes that are in this category
    /// </summary>
    public virtual ICollection<CategoryRecipe> CategoryRecipes { get; set; } = new List<CategoryRecipe>();
}
