namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class RecipeOwnDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? MainImageUrl { get; set; }
    public int Likes { get; set; }
    public double Rating { get; set; }
    public bool IsAdminApproved { get; set; }

}
