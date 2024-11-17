using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.CookDtos;
public class SummaryCookDto : IDto
{
    public int Id { get; set; }

    public required string DisplayName { get; set; }

    public uint RankingPoints { get; set; }

    public required string CookingRank { get; set; }

    public uint RecipesCount { get; set; }

}
