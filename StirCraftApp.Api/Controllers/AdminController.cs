using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Application.DTOs.RecipeDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.IngredientSpec;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;
using static StirCraftApp.Domain.Constants.RoleConstants;



namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = AdminRoleName)]
public class AdminController(IIngredientService ingredientService, IRecipeService recipeService, UserManager<AppUser> userManager) : BaseApiController
{
    #region Ingredient Management

    [HttpGet("ingredients")]
    [ProducesResponseType(typeof(PaginatedResult<BriefIngredientDto>), StatusCodes.Status200OK)]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientAdminPanelSpecParams specParams)
    {
        var spec = new IngredientFilterAdminPanelSpecification(specParams);
        var ingredients = await ingredientService
            .GetIngredientsAsync(spec, ingredient => ingredient
                .ToBriefIngredientDto());

        return Ok(ingredients);
    }

    [HttpGet("ingredients/{id}")]
    [ProducesResponseType(typeof(EditFormIngredientDto), StatusCodes.Status200OK)]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetIngredient(int id)
    {
        var ingredient = await ingredientService
            .GetIngredientByIdAsync(id, null, ingredient => ingredient
                .ToEditFormIngredientDto());

        return Ok(ingredient);
    }

    [HttpPost("ingredients")]
    [ProducesResponseType(typeof(EditFormIngredientDto), StatusCodes.Status201Created)]
    [InvalidateCache(IngredientsAdminCachePattern, IngredientsCachePattern)]
    public async Task<IActionResult> AddIngredient(FormIngredientDto ingredientDto)
    {
        var createdIngredient = await ingredientService.CreateIngredientAsync(ingredientDto);
        return CreatedAtAction(nameof(GetIngredient), new { id = createdIngredient.Id }, createdIngredient);
    }

    [HttpPut("ingredients/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(IngredientsAdminCachePattern, IngredientsCachePattern)]
    public async Task<IActionResult> UpdateOrApproveIngredient(EditFormIngredientDto ingredientDto, int id)
    {
        await ingredientService.UpdateIngredientAsync(ingredientDto, id);
        return NoContent();
    }

    [HttpDelete("ingredients/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(IngredientsAdminCachePattern, IngredientsCachePattern)]
    public async Task<IActionResult> DeleteIngredient(int id)
    {
        await ingredientService.DeleteIngredientAsync(id);
        return NoContent();
    }

    #endregion

    #region Recipe Approval

    [HttpGet("recipes/pending-approval")]
    [ProducesResponseType(typeof(PaginatedResult<BriefRecipeDto>), StatusCodes.Status200OK)]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetRecipesPendingApproval([FromQuery] PagingParams pagingParams)
    {
        var spec = new RecipePendingApprovalBriefSpecification(pagingParams);
        var recipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToBriefRecipeDtoAsync(userManager));
        return Ok(recipes);
    }

    [HttpGet("recipes/pending-approval/{id}")]
    [ProducesResponseType(typeof(DetailedRecipeAdminNotesDto), StatusCodes.Status200OK)]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetRecipePendingApproval(int id)
    {
        var spec = new RecipePendingApprovalSpecification();
        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeAdminNotesDtoAsync(userManager));
        return Ok(recipe);
    }

    [HttpPut("recipes/pending-approval/{id}/notes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(RecipeAdminCachePattern, CookOwnRecipesCachePattern)]
    public async Task<IActionResult> UpdateAdminNotesOnRecipe(int id, AdminNotesDto adminNotesDto)
    {
        await recipeService.UpdateAdminNotesAsync(id, adminNotesDto);
        return NoContent();
    }

    [HttpPost("recipes/pending-approval/{id}/approve")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(RecipeAdminCachePattern, CookOwnRecipesCachePattern, RecipesCachePattern)]
    public async Task<IActionResult> ApproveRecipe(int id)
    {
        await recipeService.ApproveRecipeAsync(id);
        return NoContent();
    }

    #endregion
}
