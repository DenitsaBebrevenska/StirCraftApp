using StirCraftApp.Application.Contracts;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.CookDtos;
public class CookAboutDto : BaseDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CookAboutMaxLength, MinimumLength = CookAboutMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string About { get; set; }

}
