namespace StirCraftApp.Application.DTOs.Recipe;

public class SummaryRecipeDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required string DifficultyLevel { get; set; }

    public string? MainImageUrl { get; set; }

    public required string CookName { get; set; }

    public required string Rating { get; set; }

    public int Likes { get; set; }

}
