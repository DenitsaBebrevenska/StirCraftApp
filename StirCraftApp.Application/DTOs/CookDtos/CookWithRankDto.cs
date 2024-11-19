using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.CookDtos;
public class CookWithRankDto : IDto
{
    public int CookId { get; set; }

    public required string CookName { get; set; }

    public required string RankTitle { get; set; }

    public required uint RankPoints { get; set; }
}
