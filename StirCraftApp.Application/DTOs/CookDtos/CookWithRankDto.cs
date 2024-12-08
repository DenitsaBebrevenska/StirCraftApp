namespace StirCraftApp.Application.DTOs.CookDtos;
public class CookWithRankDto : BaseDto
{
    public int Id { get; set; }

    public required string CookName { get; set; }

    public required string RankTitle { get; set; }

    public required uint RankPoints { get; set; }
}
