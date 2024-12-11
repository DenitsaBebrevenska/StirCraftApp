
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.JoinedTables;

/// <summary>
/// Explicit joined table created to be seeded directly
/// </summary>
public class CategoryRecipe
{
    /// <summary>
    /// The unique identifier of the category
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// A navigational property to the category of the recipe
    /// </summary>
    public virtual Category Category { get; set; } = null!;

    /// <summary>
    /// The unique identifier of the recipe
    /// </summary>
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the recipe associated with the category
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;
}
