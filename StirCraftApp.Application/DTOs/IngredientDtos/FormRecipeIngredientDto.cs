namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// Data transfer object for form recipe ingredient.
/// </summary>
public class FormRecipeIngredientDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the recipe ingredient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The unique identifier of the ingredient.
    /// </summary>
    public int IngredientId { get; set; }

    /// <summary>
    /// The quantity of the ingredient if any.
    /// </summary>
    public int? Quantity { get; set; }


    /// <summary>
    /// The unique identifier of the measurement unit of the ingredient if any.
    /// </summary>
    public int? MeasurementUnitId { get; set; }
}
