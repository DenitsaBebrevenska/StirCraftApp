namespace StirCraftApp.Domain.Constants;
public static class ExceptionErrorMessages
{
    public const string ResourceNotFound = "{0} with id {1} not found.";

    public const string UserIsNotCook = "The user with id {0} is not a cook.";

    public const string UserIsCookAlready = "The user with id {0} is a cook already.";

    public const string NotOwner = "You are not the owner of {0} with id {1}.";

    public const string UrlIdMismatch = "The {0} id in the url does not match the {0} id in the form.";

    public const string RangeError = "The {0} must be between {1} and {2}.";
}
