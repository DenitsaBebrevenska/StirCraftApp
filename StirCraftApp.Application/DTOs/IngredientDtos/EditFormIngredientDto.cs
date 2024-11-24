using StirCraftApp.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.IngredientDtos;

public class EditFormIngredientDto : IDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(IngredientNameMaxLength, MinimumLength = IngredientNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }

    public bool IsAllergen { get; set; }

    //todo but also check if at all is there and then the length
    [StringLength(IngredientPluralNameMaxLength, MinimumLength = IngredientPluralNameMinLength,
        ErrorMessage = StringLengthValidationErrorMessage)]
    public string? NameInPlural { get; set; }

    public bool IsSolid { get; set; }

    public bool IsAdminApproved { get; set; }
}
