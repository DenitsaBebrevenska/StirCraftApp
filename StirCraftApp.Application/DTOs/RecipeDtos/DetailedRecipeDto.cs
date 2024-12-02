using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos.Comment;
using StirCraftApp.Application.DTOs.RecipeDtos.Image;
using StirCraftApp.Application.DTOs.RecipeDtos.Ingredient;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class DetailedRecipeDto : IDto
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

    public int Likes { get; set; }

    public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];

    public ICollection<RecipeImageDto> Images { get; set; } = [];

    public ICollection<RecipeCommentDto> Comments { get; set; } = [];

    public IList<string> Categories { get; set; } = [];

    public bool? IsLikedByCurrentUser { get; set; }

    public int CurrentUserRating { get; set; }

}
