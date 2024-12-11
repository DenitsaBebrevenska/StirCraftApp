using StirCraftApp.Application.DTOs.ImageDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;

/// <summary>
/// Contains extension methods for mapping between <see cref="RecipeImage"/> and <see cref="RecipeImageDto"/>.
/// </summary>
public static class RecipeImageMappingExtensions
{
    public static RecipeImageDto ToRecipeImageDto(this RecipeImage recipeImage)
    {
        return new RecipeImageDto
        {
            Id = recipeImage.Id,
            Url = recipeImage.Url
        };
    }
    public static RecipeImage ToRecipeImage(this RecipeImageDto recipeImageDto)
    {
        return new RecipeImage
        {
            Id = recipeImageDto.Id,
            Url = recipeImageDto.Url
        };
    }
}
