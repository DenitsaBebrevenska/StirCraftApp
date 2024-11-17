using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class CookRecipeSummaryDto : IDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? ImageUrl { get; set; }

    public required string DifficultyLevel { get; set; }

    public double Rating { get; set; }

    public uint Likes { get; set; }

    public IList<string> Categories { get; set; } = [];
}
