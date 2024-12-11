namespace StirCraftApp.Domain.Constants;

/// <summary>
/// Role constants
/// </summary>
public static class RoleConstants
{
    public const string AdminRoleName = "Admin";
    public const string CookRoleName = "Cook";
    public const string UserRoleName = "User";

    public const string UserAndCookRoleName = UserRoleName + "," + CookRoleName;
}
