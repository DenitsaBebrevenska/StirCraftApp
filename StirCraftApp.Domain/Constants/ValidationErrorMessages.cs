namespace StirCraftApp.Domain.Constants;

/// <summary>
/// Constant messages for errors in DTO validation
/// </summary>
public static class ValidationErrorMessages
{
    public const string StringLengthValidationErrorMessage =
        "{0} must be between {2} and {1} characters long.";

    public const string StringMaxLengthValidationErrorMessage =
        "{0} must be at maxium {1} characters long.";


    public const string RequiredValidationErrorMessage =
        "{0} is required.";
}


