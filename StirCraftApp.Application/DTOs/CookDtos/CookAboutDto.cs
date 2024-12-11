using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.CookDtos;

/// <summary>
/// Data transfer object for Cook about.
/// Get validated as data comes from the client.
/// </summary>
public class CookAboutDto : BaseDto
{
    /// <summary>
    /// Cook data for the About section.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CookAboutMaxLength, MinimumLength = CookAboutMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string About { get; set; }

}
