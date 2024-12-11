using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;
namespace StirCraftApp.Application.DTOs.UserDtos;

/// <summary>
/// Data transfer object for registering a new user
/// Gets validated as it deals with user input
/// </summary>
public class UserRegisterDto : BaseDto
{
    /// <summary>
    /// The display name the user wishes to register with
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(UserDisplayNameMaxLength, MinimumLength = UserDisplayNameMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public string DisplayName { get; set; } = null!;

    /// <summary>
    /// The email the user wishes to register with
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    /// <summary>
    /// The password the user wished to use to log in
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    public string Password { get; set; } = null!;
}
