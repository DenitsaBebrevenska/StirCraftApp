using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class IngredientService(IUnitOfWork unit) : IIngredientService
{
    public async Task<EditFormIngredientDto> GetIngredientByIdAsync(int id, ISpecification<Ingredient>? spec)
    {
        var ingredient = await unit.Repository<Ingredient>()
            .GetByIdAsync(spec, id);

        if (ingredient == null)
        {
            throw new Exception($"Ingredient not found");
        }

        return ingredient.ToEditFormIngredientDto();
    }


    public async Task<PaginatedResult> GetIngredientsAsync(ISpecification<Ingredient>? spec, string dtoName)
    {
        var ingredients = await unit.Repository<Ingredient>()
            .GetAllAsync(spec);

        var count = await unit.Repository<Ingredient>()
            .CountAsync(spec);

        var ingredientDtos = ingredients.Select(i => ConvertToDto(i, dtoName)).ToList();

        var paginatedResult = new PaginatedResult(spec.Skip,
            spec.Take,
            count,
            ingredientDtos);

        return paginatedResult;
    }

    public async Task<IList<BriefIngredientDto>> GetIngredientsNotPaged()
    {
        var ingredients = await unit.Repository<Ingredient>()
            .GetAllAsync(null);

        //todo rethink this one
        var dtos = ingredients
            .Where(i => i.IsAdminApproved)
            .OrderBy(i => i.Name)
            .Select(i => i.ToBriefIngredientDto())
            .ToList();

        return dtos;
    }


    public async Task SuggestIngredient(SuggestIngredientDto ingredient)
    {
        await unit.Repository<Ingredient>()
            .AddAsync(new Ingredient
            {
                Name = ingredient.Name
            });

        await unit.CompleteAsync();
    }

    public async Task CreateIngredientAsync(FormIngredientDto ingredient)
    {
        await unit.Repository<Ingredient>()
            .AddAsync(new Ingredient
            {
                Name = ingredient.Name,
                IsAllergen = ingredient.IsAllergen,
                IsAdminApproved = true
            });

        await unit.CompleteAsync();
    }

    public async Task UpdateIngredientAsync(EditFormIngredientDto ingredientDto, int id)
    {
        var ingredientToUpdate = await unit.Repository<Ingredient>()
            .GetByIdAsync(null, id);

        if (ingredientToUpdate == null)
        {
            throw new Exception($"Ingredient with id {id} not found");
        }

        if (ingredientDto.Id != id)
        {
            throw new Exception("Id mismatch");
        }

        ingredientToUpdate.UpdateFromDto(ingredientDto);

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

    private static object ConvertToDto(Ingredient ingredient, string dtoName)
    {
        return dtoName switch
        {
            nameof(BriefIngredientDto) => ingredient.ToBriefIngredientDto(),
            nameof(SuggestIngredientDto) => ingredient.ToSuggestIngredientDto(),
            nameof(FormIngredientDto) => ingredient.ToFormIngredientDto(),
            nameof(EditFormIngredientDto) => ingredient.ToEditFormIngredientDto(),
            _ => throw new ArgumentException("Invalid DTO type")
        };
    }
}
