using System.ComponentModel.DataAnnotations;

namespace StirCraftApp.Application.DTOs.CommentDtos;
using static Domain.Constants.EntityConstraints;
using static Domain.Constants.ValidationErrorMessages;

/// <summary>
/// Data transfer object for comment form.
/// Validates the input data for creating a comment.
/// </summary>
public class CommentFormDto : BaseDto
{
    /// <summary>
    /// Gets or sets the title of the comment.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Title { get; set; }

    /// <summary>
    /// Gets or sets the body of the comment.
    /// </summary>

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentBodyMaxLength, MinimumLength = CommentBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }

}
