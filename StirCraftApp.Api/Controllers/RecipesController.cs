using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService, ICookService cookService) : ControllerBase
{
    // get recipes with specs and not, get recipe by id, create recipe, edit recipe, delete recipe
    [HttpGet]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec, nameof(SummaryRecipeDto));
        return Ok(recipes);
    }

    [HttpGet("top/{count}")]
    public async Task<IActionResult> GetTopNRecipes(int count)
    {
        var recipes = await recipeService.GetTopNRecipes(count, nameof(BriefRecipeDto));
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await recipeService.GetRecipeByIdAsync(id, nameof(DetailedRecipeDto));
        return Ok(recipe);
    }

    [HttpGet("cook/{id}")]
    public async Task<IActionResult> GetRecipesByCookId(int id)
    {
        var spec = new RecipeByCookIdSpecification(id);
        var cookRecipes = await recipeService.GetRecipesAsync(spec, nameof(CookRecipeSummaryDto));
        return Ok(cookRecipes);
    }


    [HttpGet("own")]
    public async Task<IActionResult> GetCurrentCookRecipes()
    {
        var userId = User.GetId();
        var cookId = await cookService.GetCookId(userId);

        if (cookId == null)
        {
            return BadRequest("You are not a cook");
        }

        var recipes = await recipeService.GetRecipesAsync(new RecipesCurrentCookSpecification((int)cookId, new PagingParams())
            , nameof(BriefCookRecipeDto));

        return Ok(recipes);
    }

    //implementing that through any service is not necessary, complicates it for no good reason
    [HttpGet("difficultyLevels")]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }

}
