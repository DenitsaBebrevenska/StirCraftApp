namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for summary recipe
/// </summary>
public class SummaryRecipeDto : BaseDto
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
    /// The difficulty level of a recipe as string
    /// </summary>
    public required string DifficultyLevel { get; set; }

    /// <summary>
    /// The url leading to the first image from the recipe images collection
    /// </summary>
    public string? MainImageUrl { get; set; }

    /// <summary>
    /// The Display name of the user that submitted the recipe
    /// </summary>
    public required string CookName { get; set; }

    /// <summary>
    /// The average rating of a recipe
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Total likes of a recipe
    /// </summary>
    public int Likes { get; set; }

    /// <summary>
    /// A collection of category names representing the categories with which the recipe is associated
    /// </summary>
    public IList<string> Categories { get; set; } = [];

}
