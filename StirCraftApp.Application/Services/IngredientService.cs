using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Application.Services;
public class IngredientService(IUnitOfWork unit) : IIngredientService
{
    public async Task<DetailedIngredientDto> GetIngredientByIdAsync(int id)
    {
        var ingredient = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredient == null)
        {
            throw new Exception($"Ingredient with id {id} not found");
        }

        return ingredient.ToDetailedIngredientDto();
    }

    public async Task<PaginatedResult> GetIngredientsAsync(BaseSpecification<Ingredient> spec)
    {
        var ingredients = await unit.Repository<Ingredient>()
            .GetAllAsync(spec);

        var ingredientDtos = ingredients.Select(i => (object)i.ToDetailedIngredientDto()).ToList();

        var paginatedResult = new PaginatedResult(spec.Skip,
            spec.Take,
            ingredientDtos.Count,
            ingredientDtos);

        return paginatedResult;
    }

    public Task SuggestIngredient(SuggestIngredientDto ingredient)
    {
        throw new NotImplementedException();
    }

    public async Task CreateIngredientAsync(FormIngredientDto ingredient)
    {
        await unit.Repository<Ingredient>()
            .AddAsync(new Ingredient
            {
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen,
                NameInPlural = ingredient.NameInPlural,
                IsSolid = ingredient.IsSolid
            });
    }

    public async Task UpdateIngredientAsync(FormIngredientDto ingredient, int id)
    {
        var ingredientToUpdate = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredientToUpdate == null)
        {
            throw new Exception($"Ingredient with id {id} not found");
        }

        unit.Repository<Ingredient>()
            .Update(ingredientToUpdate);

        await unit.CompleteAsync();

    }

    public async Task DeleteIngredientAsync(int id)
    {
        var ingredientToDelete = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredientToDelete == null)
        {
            throw new Exception($"Ingredient with id {id} not found");
        }

        unit.Repository<Ingredient>().Delete(ingredientToDelete);

        await unit.CompleteAsync();
    }
}
