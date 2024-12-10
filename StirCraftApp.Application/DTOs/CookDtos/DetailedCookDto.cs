namespace StirCraftApp.Application.DTOs.CookDtos;
public class DetailedCookDto : BaseDto
{
    public int Id { get; set; }
    public required string DisplayName { get; set; }

    public string? AvatarUrl { get; set; }
    public required string About { get; set; }

    public int RankingPoints { get; set; }

    public int RecipesCount { get; set; }

    public int RecipeLikes { get; set; }

    public required string CookingRank { get; set; }
}
