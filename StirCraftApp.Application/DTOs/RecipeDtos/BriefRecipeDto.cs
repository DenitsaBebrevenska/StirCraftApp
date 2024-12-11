namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for brief recipe information
/// </summary>
public class BriefRecipeDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the recipe
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The recipe name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The Display name of the user that submitted the recipe
    /// </summary>
    public required string CookName { get; set; }

    /// <summary>
    /// The url leading to the first image from the recipe images collection
    /// </summary>
    public string? MainImageUrl { get; set; }
}
