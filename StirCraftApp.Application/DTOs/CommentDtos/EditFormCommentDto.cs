using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.CommentDtos;
public class EditFormCommentDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentTitleMaxLength, MinimumLength = CommentTitleMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Title { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(CommentBodyMaxLength, MinimumLength = CommentBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }

}
