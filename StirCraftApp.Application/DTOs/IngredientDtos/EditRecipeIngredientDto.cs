using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// An edit form ingredient data transfer object connected to a specific ingredient inside a recipe.
/// Gets validated as it deals with user input.
/// </summary>
public class EditRecipeIngredientDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the recipe ingredient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string IngredientName { get; set; }

    /// <summary>
    /// The unique identifier of the ingredient.
    /// </summary>
    public int IngredientId { get; set; }

    /// <summary>
    /// The quantity of the ingredient if any.
    /// </summary>
    public int? Quantity { get; set; }

    /// <summary>
    /// The measurement unit of the ingredient if any.
    /// </summary>
    public string? MeasurementAbbreviation { get; set; }

    /// <summary>
    /// The unique identifier of the measurement unit of the ingredient if any.
    /// </summary>
    public int? MeasurementUnitId { get; set; }
}
