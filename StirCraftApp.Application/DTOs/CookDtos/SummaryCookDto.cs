namespace StirCraftApp.Application.DTOs.CookDtos;
public class SummaryCookDto : BaseDto
{
    public int Id { get; set; }

    public required string DisplayName { get; set; }

    public string? AvatarUrl { get; set; }
    public int RankingPoints { get; set; }

    public required string CookingRank { get; set; }

    public int RecipesCount { get; set; }

}
