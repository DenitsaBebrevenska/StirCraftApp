
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Domain.JoinedTables;

/// <summary>
/// Explicit joined table created to be seeded directly
/// </summary>
public class UserFavoriteRecipe
{
    /// <summary>
    /// The unique identifier of the user who has the recipe as favorite
    /// </summary>
    public required string UserId { get; set; }

    /// <summary>
    /// A navigational property to the User that has the recipe as favorite
    /// </summary>
    public virtual AppUser AppUser { get; set; } = null!;

    /// <summary>
    /// The unique identifier of the recipe that is being favorited by the used
    /// </summary>
    public int RecipeId { get; set; }

    /// <summary>
    /// A navigational property to the Recipe that is being favorited by the user
    /// </summary>
    public virtual Recipe Recipe { get; set; } = null!;
}
