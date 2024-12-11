using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.CommentDtos;

/// <summary>
/// Data transfer object for editing a comment.
/// Validates input data.
/// </summary>
public class EditFormCommentDto : BaseDto
{
    /// <summary>
    /// Unique identifier of the comment.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the comment.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Title { get; set; }

    /// <summary>
    /// Body of the comment.
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentBodyMaxLength, MinimumLength = CommentBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }

}
