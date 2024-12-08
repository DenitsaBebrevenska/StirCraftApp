using System.ComponentModel.DataAnnotations;


namespace StirCraftApp.Application.DTOs.IngredientDtos;
using static Domain.Constants.EntityConstraints;
using static Domain.Constants.ValidationErrorMessages;

public class SuggestIngredientDto : BaseDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }
}
