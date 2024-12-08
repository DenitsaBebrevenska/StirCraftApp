﻿using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Application.DTOs.IngredientDtos;
using System.ComponentModel.DataAnnotations;
using static StirCraftApp.Domain.Constants.EntityConstraints;
using static StirCraftApp.Domain.Constants.ValidationErrorMessages;

namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class FormRecipeDto : BaseDto
{
    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(RecipeNameMaxLength, MinimumLength = RecipeNameMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string Name { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    [StringLength(RecipeDescriptionMaxLength, MinimumLength = RecipeDescriptionMinLength, ErrorMessage = StringLengthValidationErrorMessage)]
    public required string PreparationSteps { get; set; }

    [Required(ErrorMessage = RequiredValidationErrorMessage)]
    public required string DifficultyLevel { get; set; }

    public IList<FormRecipeIngredientDto> RecipeIngredients { get; set; } = [];

    public IList<RecipeImageDto> RecipeImages { get; set; } = [];

    public IList<int> CategoryRecipes { get; set; } = [];


}
