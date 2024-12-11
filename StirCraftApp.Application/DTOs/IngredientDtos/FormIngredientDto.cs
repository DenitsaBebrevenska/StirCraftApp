using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// A create form ingredient data transfer object.
/// Gets validated as it deals with user input.
/// </summary>
public class FormIngredientDto : BaseDto
{
    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    [Required]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }


    /// <summary>
    /// A flag indicating whether the ingredient is an allergen.
    /// </summary>
    public bool IsAllergen { get; set; }

}
