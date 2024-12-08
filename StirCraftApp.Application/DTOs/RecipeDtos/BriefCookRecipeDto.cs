namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class BriefCookRecipeDto : BaseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public string? MainImageUrl { get; set; }

    public double Rating { get; set; }

    public int Likes { get; set; }

}
