namespace StirCraftApp.Application.DTOs;
public class DetailedRecipeDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string PreparationSteps { get; set; }

    public required string DifficultyLevel { get; set; }

    public int CookId { get; set; }

    public required string CookName { get; set; }

    public required string CreatedOn { get; set; }

    public required string UpdatedOn { get; set; }

    public double Rating { get; set; }

    public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];

    public ICollection<RecipeImageDto> Images { get; set; } = [];

    public ICollection<RecipeCommentDto> Comments { get; set; } = [];
}
