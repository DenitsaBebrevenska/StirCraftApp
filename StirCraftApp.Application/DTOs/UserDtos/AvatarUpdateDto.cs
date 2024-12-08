using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.UserDtos;
public class AvatarUpdateDto : BaseDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(ImageUrlMaxLength, ErrorMessage = StringMaxLengthValidationErrorMessage)]
    public required string ImageUrl { get; set; }
}
