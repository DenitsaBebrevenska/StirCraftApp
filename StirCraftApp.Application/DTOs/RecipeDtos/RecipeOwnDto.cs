namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for recipe specific to cook area view
/// </summary>
public class RecipeOwnDto : BaseDto
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
    /// The url leading to the first image from the recipe images collection
    /// </summary>
    public string? MainImageUrl { get; set; }

    /// <summary>
    /// Total likes of a recipe
    /// </summary>
    public int Likes { get; set; }

    /// <summary>
    /// The average rating of a recipe
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// A flag indicating if recipe is approved by admin
    /// </summary>
    public bool IsAdminApproved { get; set; }

}
