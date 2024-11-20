using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class IngredientMappingExtensions
{
    public static FormIngredientDto ToFormIngredientDto(this Ingredient ingredient)
    {
        return new FormIngredientDto
        {
            Name = ingredient.Name,
            IsAllergen = ingredient.IsAllergen,
            NameInPlural = ingredient.NameInPlural,
            IsSolid = ingredient.IsSolid
        };
    }

    public static DetailedIngredientDto ToDetailedIngredientDto(this Ingredient ingredient)
    {
        return new DetailedIngredientDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            IsAllergen = ingredient.IsAllergen,
            NameInPlural = ingredient.NameInPlural,
            IsSolid = ingredient.IsSolid
        };
    }

}
