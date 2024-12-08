namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class BriefRecipeDto : BaseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string CookName { get; set; }

    public string? MainImageUrl { get; set; }
}
