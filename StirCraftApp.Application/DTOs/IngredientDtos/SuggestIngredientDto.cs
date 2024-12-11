using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;

/// <summary>
/// Data transfer object to suggesting an ingredient
/// Get validated as it deals with user input
/// </summary>
public class SuggestIngredientDto : BaseDto
{
    /// <summary>
    /// The name of the suggested ingredient
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }
}
