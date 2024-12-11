using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.ReplyDtos;

/// <summary>
/// Data transfer object for reply creation
/// Get validated as it deals with user input
/// </summary>
public class ReplyFormDto : BaseDto
{
    /// <summary>
    /// The body of the reply
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(ReplyBodyMaxLength, MinimumLength = ReplyBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }
}
