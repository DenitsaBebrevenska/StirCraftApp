using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Domain.Specifications;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService) : ControllerBase
{
    // get recipes with specs and not, get recipe by id, create recipe, edit recipe, delete recipe
    [HttpGet]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams? specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec);
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await recipeService.GetRecipeByIdAsync(id);
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRecipe(FormRecipeDto createRecipeDto)
    {
        await recipeService.CreateRecipeAsync(createRecipeDto);
        //todo return created recipe
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRecipe(int id, FormRecipeDto updateRecipeDto)
    {
        updateRecipeDto.Id = id;
        await recipeService.UpdateRecipeAsync(updateRecipeDto);
        //todo return updated recipe ???
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await recipeService.DeleteRecipeAsync(id);
        return Ok();
    }
}
