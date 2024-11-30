using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.RecipeDtos.Image;
public class RecipeImageDto : IDto
{
    public int Id { get; set; }
    public required string Url { get; set; }
}
