using StirCraftApp.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class FormIngredientDto : IDto
{
    [Required]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }

    public bool IsAllergen { get; set; }

    [StringLength(IngredientPluralNameMaxLength, MinimumLength = IngredientPluralNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string? NameInPlural { get; set; }

    public bool IsSolid { get; set; }

    public bool IsAdminApproved = true;

}
