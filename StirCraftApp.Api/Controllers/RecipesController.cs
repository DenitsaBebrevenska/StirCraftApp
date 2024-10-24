using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IService<Recipe> recipeService) : ControllerBase
{
    //get recipes with specs and not, get recipe by id, create recipe, edit recipe, delete recipe
    //[HttpGet]
    ////public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams? specParams)
    //{
    //    var recipes = recipeService
    //        .GetAllWithSpecAsync(specParams.)
    //    return Ok();
    //}

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
