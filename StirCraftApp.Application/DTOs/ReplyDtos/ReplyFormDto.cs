using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.ReplyDtos;
public class ReplyFormDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(ReplyBodyMaxLength, MinimumLength = ReplyBodyMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Body { get; set; }
}
