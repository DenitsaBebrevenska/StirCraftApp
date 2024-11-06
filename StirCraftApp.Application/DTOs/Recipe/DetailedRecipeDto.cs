﻿using StirCraftApp.Application.DTOs.Recipe.Comment;
using StirCraftApp.Application.DTOs.Recipe.Image;
using StirCraftApp.Application.DTOs.Recipe.Ingredient;

namespace StirCraftApp.Application.DTOs.Recipe;
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

    public IList<string> Categories { get; set; } = [];
}