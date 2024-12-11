using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.ReplyDtos;

/// <summary>
/// Data transfer object for editing a reply.
/// Gets validated as it deals with user input.
/// </summary>
public class ReplyEditFormDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the reply
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The body of the reply
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(ReplyBodyMaxLength, MinimumLength = ReplyBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }
}
