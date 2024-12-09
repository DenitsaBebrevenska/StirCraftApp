using System.Security.Claims;

namespace StirCraftApp.Infrastructure.Extensions;

public static class ClaimsPrincipleExtensions
{
    public static string? GetId(this ClaimsPrincipal user)
    {
        var id = user.FindFirstValue(ClaimTypes.NameIdentifier);

        return id;
    }
}

