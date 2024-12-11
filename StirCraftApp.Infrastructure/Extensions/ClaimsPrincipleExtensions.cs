using System.Security.Claims;

namespace StirCraftApp.Infrastructure.Extensions;

/// <summary>
/// Claims principal extensions
/// </summary>
public static class ClaimsPrincipleExtensions
{
    /// <summary>
    /// Extending the current user`s claims pricipal to find the user ID
    /// </summary>
    /// <param name="user">The current user`s claims principal</param>
    /// <returns>The ID of the user if any.</returns>
    public static string? GetId(this ClaimsPrincipal user)
    {
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return id;
    }
}

