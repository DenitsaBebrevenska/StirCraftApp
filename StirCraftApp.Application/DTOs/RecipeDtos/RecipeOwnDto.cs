namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class RecipeOwnDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? MainImageUrl { get; set; }
    public uint Likes { get; set; }
    public string? Rating { get; set; }
    public bool IsAdminApproved { get; set; }

}
