using StirCraftApp.Application.DTOs.CommentDtos;
using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;

namespace StirCraftApp.Application.DTOs.RecipeDtos;


/// <summary>
/// DTO for recipe with current user likes and rating
/// </summary>
public class DetailedRecipeDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the recipe
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The recipe name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Description of the recipe`s preparation
    /// </summary>
    public required string PreparationSteps { get; set; }

    /// <summary>
    /// The difficulty level of a recipe as string
    /// </summary>
    public required string DifficultyLevel { get; set; }

    /// <summary>
    /// The unique identifier of the cook that created the recipe
    /// </summary>
    public int CookId { get; set; }

    /// <summary>
    /// The Display name of the user that submitted the recipe
    /// </summary>
    public required string CookName { get; set; }

    /// <summary>
    /// The date and time UTC the recipe was created on
    /// </summary>
    public required string CreatedOn { get; set; }

    /// <summary>
    /// The date and time UTC the recipe was last edited on
    /// </summary>
    public required string UpdatedOn { get; set; }

    /// <summary>
    /// The average rating of a recipe
    /// </summary>
    public double Rating { get; set; }

    /// <summary>
    /// Total likes of a recipe
    /// </summary>
    public int Likes { get; set; }

    /// <summary>
    /// A collection of DTOs representing the ingredients that take part in the recipe
    /// </summary>
    public ICollection<RecipeIngredientDto> Ingredients { get; set; } = [];

    /// <summary>
    /// A collection of DTOs representing the image urls leading to recipe`s images
    /// </summary>
    public ICollection<RecipeImageDto> Images { get; set; } = [];


    /// <summary>
    /// A collection of DTOs representing the comments made on the recipe
    /// </summary>
    public ICollection<RecipeCommentDto> Comments { get; set; } = [];

    /// <summary>
    /// A collection of category names representing the categories with which the recipe is associated
    /// </summary>
    public IList<string> Categories { get; set; } = [];

    /// <summary>
    /// A flag indicating if the recipe is like by the current user
    /// </summary>
    public bool IsLikedByCurrentUser { get; set; }

    /// <summary>
    /// The rating (0 to 5) which the user rated the current recipe
    /// </summary>
    public int CurrentUserRating { get; set; }

}
