using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Extensions;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Domain.Enums;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController(IRecipeService recipeService, ICookingRankService cookingRankService) : ControllerBase
{
    // get recipes with specs and not, get recipe by id, create recipe, edit recipe, delete recipe
    [HttpGet]
    public async Task<IActionResult> GetRecipes([FromQuery] RecipeSpecParams specParams)
    {
        var spec = new RecipeFilterSortIncludeSpecification(specParams);
        var recipes = await recipeService.GetRecipesAsync(spec, nameof(SummaryRecipeDto));
        return Ok(recipes);
    }

    [HttpGet("top3")]
    public async Task<IActionResult> GetTopThree()
    {
        var recipes = await recipeService.GetTopThreeRecipes(nameof(BriefRecipeDto));
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

    //implementing that through any service is not necessary, complicates it for no good reason
    [HttpGet("difficultyLevels")]
    public IActionResult GetDifficultyLevels()
    {
        var difficultyLevels = Enum.GetNames(typeof(DifficultyLevel));
        return Ok(difficultyLevels);
    }

    [HttpPost("recipe-like/{id}")]
    public async Task<IActionResult> LikeRecipe(int id)
    {
        var userId = User.GetId();
        await recipeService.AddRecipeToUsersFavoritesAsync(userId, id);
        return Ok();
    }

    [HttpPost("recipe-unlike/{id}")]
    public async Task<IActionResult> UnlikeRecipe(int id)
    {
        var userId = User.GetId();
        await recipeService.RemoveRecipeToUsersFavoritesAsync(userId, id);
        return Ok();
    }

}
