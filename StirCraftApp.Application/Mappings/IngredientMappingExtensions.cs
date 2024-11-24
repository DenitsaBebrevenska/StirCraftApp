using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class IngredientMappingExtensions
{
    public static SuggestIngredientDto ToSuggestIngredientDto(this Ingredient ingredient)
    {
        return new SuggestIngredientDto
        {
            Name = ingredient.Name
        };
    }

    public static BriefIngredientDto ToBriefIngredientDto(this Ingredient ingredient)
    {
        return new BriefIngredientDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            IsAllergen = ingredient.IsAllergen
        };
    }
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

    public static EditFormIngredientDto ToEditFormIngredientDto(this Ingredient ingredient)
    {
        return new EditFormIngredientDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            IsAllergen = ingredient.IsAllergen,
            NameInPlural = ingredient.NameInPlural,
            IsSolid = ingredient.IsSolid,
            IsAdminApproved = ingredient.IsAdminApproved
        };
    }

    public static void UpdateFromDto(this Ingredient ingredient, EditFormIngredientDto formIngredientDto)
    {
        ingredient.Name = formIngredientDto.Name;
        ingredient.IsAllergen = formIngredientDto.IsAllergen;
        ingredient.NameInPlural = formIngredientDto.NameInPlural;
        ingredient.IsSolid = formIngredientDto.IsSolid;
        ingredient.IsAdminApproved = true;
    }

}
