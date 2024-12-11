namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for recipe representing the current state of user likes and total likes given
/// </summary>
public class FavoriteRecipeToggleDto : BaseDto
{
    /// <summary>
    /// A flag indicating if the current recipe is liked by the current user
    /// </summary>
    public bool IsFavorite { get; set; }

    /// <summary>
    /// Total likes a recipe has
    /// </summary>
    public int TotalLikes { get; set; }
}
