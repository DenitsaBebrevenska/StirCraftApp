namespace StirCraftApp.Application.DTOs.CookDtos;

/// <summary>
/// DTO class that represents detailed information about a cook.
/// </summary>
public class DetailedCookDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the cook.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The Display name of the user that is a cook.
    /// </summary>
    public required string DisplayName { get; set; }

    /// <summary>
    /// The url to the avatar image of the cook if any.
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// The general information about the cook.
    /// </summary>
    public required string About { get; set; }

    /// <summary>
    /// The ranking points of the cook.
    /// </summary>
    public int RankingPoints { get; set; }

    /// <summary>
    /// Total recipe count of the cook of those recipes that are admin approved.
    /// </summary>
    public int RecipesCount { get; set; }

    /// <summary>
    /// Total likes of the recipes of the cook.
    /// </summary>
    public int RecipeLikes { get; set; }

    /// <summary>
    /// Cooking rank of the cook as a string.
    /// </summary>

    public required string CookingRank { get; set; }
}
