using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class BriefRecipeDto : IDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string CookName { get; set; }

    public string? MainImageUrl { get; set; }
}
