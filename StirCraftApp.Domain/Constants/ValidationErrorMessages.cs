namespace StirCraftApp.Domain.Constants;

public static class ValidationErrorMessages
{
    public const string StringLengthValidationErrorMessage =
        "The field {0} must be between {2} and {1} characters long.";

    public const string UrlLengthValidationErrorMessage =
        "The field {0} at maxium {1} characters long.";


    public const string RequiredValidationErrorMessage =
        "The field {0} is required.";
}


