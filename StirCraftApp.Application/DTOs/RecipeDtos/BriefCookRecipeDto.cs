using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class BriefCookRecipeDto : IDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? MainImageUrl { get; set; }

    public double Rating { get; set; }

    public uint Likes { get; set; }

}
