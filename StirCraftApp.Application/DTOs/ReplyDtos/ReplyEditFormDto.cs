using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.ReplyDtos;
public class ReplyEditFormDto : BaseDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(ReplyBodyMaxLength, MinimumLength = ReplyBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }
}
