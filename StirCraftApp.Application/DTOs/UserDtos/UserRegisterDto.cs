using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;
namespace StirCraftApp.Application.DTOs.UserDtos;
public class UserRegisterDto : BaseDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(UserDisplayNameMaxLength, MinimumLength = UserDisplayNameMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public string DisplayName { get; set; } = null!;

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    public string Password { get; set; } = null!;
}
