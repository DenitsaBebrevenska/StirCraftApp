namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// Data transfer object for form recipe ingredient.
/// </summary>
public class RecipeIngredientDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the recipe ingredient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the ingredient
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The quantity of the ingredient if any.
    /// </summary>
    public int? Quantity { get; set; }


    /// <summary>
    /// The unique identifier of the measurement unit of the ingredient if any.
    /// </summary>
    public string? MeasurementUnitName { get; set; }
}
