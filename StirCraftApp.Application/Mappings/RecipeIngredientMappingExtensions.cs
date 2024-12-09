using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class RecipeIngredientMappingExtensions
{
    public static RecipeIngredientDto ToRecipeIngredientDto(this RecipeIngredient recipeIngredient)
    {
        return new RecipeIngredientDto
        {
            Id = recipeIngredient.Id,
            Name = recipeIngredient.Ingredient.Name,
            Quantity = recipeIngredient.Quantity,
            MeasurementUnitName = recipeIngredient.MeasurementUnit?.Name
        };
    }

    public static EditRecipeIngredientDto ToEditRecipeIngredientDto(this RecipeIngredient recipeIngredient)
    {
        return new EditRecipeIngredientDto
        {
            Id = recipeIngredient.Id,
            IngredientName = recipeIngredient.Ingredient.Name,
            IngredientId = recipeIngredient.Ingredient.Id,
            Quantity = recipeIngredient.Quantity,
            MeasurementUnitId = recipeIngredient.MeasurementUnitId,
            MeasurementAbbreviation = recipeIngredient.MeasurementUnit?.Abbreviation
        };
    }

    public static FormRecipeIngredientDto ToFormRecipeIngredientDto(this RecipeIngredient recipeIngredient)
    {
        return new FormRecipeIngredientDto
        {
            Id = recipeIngredient.Id,
            IngredientId = recipeIngredient.IngredientId,
            Quantity = recipeIngredient.Quantity,
            MeasurementUnitId = recipeIngredient.MeasurementUnitId
        };
    }


    public static RecipeIngredient ToRecipeIngredient(this FormRecipeIngredientDto
        formRecipeIngredientDto)
    {
        return new RecipeIngredient
        {
            Id = formRecipeIngredientDto.Id,
            IngredientId = formRecipeIngredientDto.IngredientId,
            Quantity = formRecipeIngredientDto.Quantity,
            MeasurementUnitId = formRecipeIngredientDto.MeasurementUnitId
        };
    }

}
