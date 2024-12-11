namespace StirCraftApp.Application.DTOs.CookDtos;

/// <summary>
/// Cook data transfer object with rank.
/// </summary>
public class CookWithRankDto : BaseDto
{
    /// <summary>
    /// Unique identifier for the cook.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The Display name of the user who is a cook
    /// </summary>
    public required string CookName { get; set; }

    /// <summary>
    /// The rank title of the cook as string.
    /// </summary>
    public required string RankTitle { get; set; }

    /// <summary>
    /// The rank points of the cook.
    /// </summary>
    public required int RankPoints { get; set; }
}
