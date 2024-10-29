using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
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
        var spec = new RecipeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec);
        return Ok(recipes);
    }

    //[HttpGet("{id:int}")]
    //public async Task<IActionResult> GetRecipe(int id)
    //{
    //    var recipe = await _recipeRepository
    //        .GetByIdAsync(id);

    //    if (recipe == null)
    //    {
    //        return NotFound();
    //    }

    //    return Ok(recipe);
    //}
}
