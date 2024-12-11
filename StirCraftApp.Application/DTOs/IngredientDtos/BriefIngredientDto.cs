namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// A brief ingredient data transfer object.
/// </summary>
public class BriefIngredientDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the ingredient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// A flag indicating whether the ingredient is an allergen.
    /// </summary>
    public bool IsAllergen { get; set; }

}
