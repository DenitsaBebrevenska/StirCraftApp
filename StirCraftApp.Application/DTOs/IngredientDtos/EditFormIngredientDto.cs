using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// An edit form ingredient data transfer object.
/// Gets validated as it deals with user input.
/// </summary>
public class EditFormIngredientDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the ingredient.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the ingredient.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }

    /// <summary>
    /// A flag indicating whether the ingredient is an allergen.
    /// </summary>
    public bool IsAllergen { get; set; }

    /// <summary>
    /// A flag indicating whether the ingredient is approved by admin.
    /// </summary>
    public bool IsAdminApproved { get; set; }
}
