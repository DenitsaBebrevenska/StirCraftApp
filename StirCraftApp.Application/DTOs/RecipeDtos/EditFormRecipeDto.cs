using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.RecipeDtos;

/// <summary>
/// Data transfer object for editing a recipe
/// Gets validated as it deals with user input.
/// </summary>
public class EditFormRecipeDto : BaseDto
{

    /// <summary>
    /// The unique identifier of the recipe
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The recipe name
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the recipe`s preparation
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string PreparationSteps { get; set; }

    /// <summary>
    /// The difficulty level of a recipe as string
    /// </summary>
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    public required string DifficultyLevel { get; set; }

    /// <summary>
    /// A collection of DTOs representing the ingredients that take part in the recipe
    /// </summary>
    public IList<FormRecipeIngredientDto> RecipeIngredients { get; set; } = [];

    /// <summary>
    /// A collection of DTOs representing the image urls leading to recipe`s images
    /// </summary>
    public IList<RecipeImageDto> RecipeImages { get; set; } = [];

    /// <summary>
    /// A collection of category names representing the categories with which the recipe is associated
    /// </summary>
    public IList<int> CategoryRecipes { get; set; } = [];


}
