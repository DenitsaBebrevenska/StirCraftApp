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

/// <summary>
/// Provides administrative endpoints for managing ingredients and approving recipes in the StirCraft application.
/// </summary>
/// <remarks>
/// This controller handles admin-related operations for the StirCraft application.
/// Inherits from the BaseApiController class, Authorize attribute is applied by default, unless overridden.
/// Routing is configured to use the "api/admin/" path.
/// This controller is restricted to users with the "Admin" role. 
/// It includes functionality for managing ingredients and handling recipe approvals, including fetching, updating, and deleting records.
/// </remarks>
[Authorize(Roles = AdminRoleName)]
public class AdminController(IIngredientService ingredientService, IRecipeService recipeService, UserManager<AppUser> userManager) : BaseApiController
{
    #region Ingredient Management

    /// <summary>
    /// Retrieves a paginated list of ingredients for administrative management.
    /// </summary>
    /// <param name="specParams">Parameters for filtering and pagination.</param>
    /// <returns>
    /// Returns a 200 OK status with the paginated ingredient data.
    /// </returns>
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

    /// <summary>
    /// Retrieves detailed information about a specific ingredient by ID.
    /// </summary>
    /// <param name="id">The ID of the ingredient to retrieve.</param>
    /// <returns>
    /// Returns a 200 OK status with the ingredient details.
    /// </returns>
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

    /// <summary>
    /// Creates a new ingredient.
    /// </summary>
    /// <param name="ingredientDto">The data transfer object containing ingredient details.</param>
    /// <returns>
    /// Returns a 201 Created status with the created ingredient's details and location.
    /// </returns>
    [HttpPost("ingredients")]
    [ProducesResponseType(typeof(EditFormIngredientDto), StatusCodes.Status201Created)]
    [InvalidateCache(IngredientsAdminCachePattern, IngredientsCachePattern)]
    public async Task<IActionResult> AddIngredient(FormIngredientDto ingredientDto)
    {
        var createdIngredient = await ingredientService.CreateIngredientAsync(ingredientDto);
        return CreatedAtAction(nameof(GetIngredient), new { id = createdIngredient.Id }, createdIngredient);
    }

    /// <summary>
    /// Updates or approves an existing ingredient.
    /// </summary>
    /// <param name="ingredientDto">The updated ingredient data.</param>
    /// <param name="id">The ID of the ingredient to update.</param>
    /// <returns>
    /// Always returns a 204 No Content status on successful update or approval.
    /// </returns>
    [HttpPut("ingredients/{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(IngredientsAdminCachePattern, IngredientsCachePattern)]
    public async Task<IActionResult> UpdateOrApproveIngredient(EditFormIngredientDto ingredientDto, int id)
    {
        await ingredientService.UpdateIngredientAsync(ingredientDto, id);
        return NoContent();
    }

    /// <summary>
    /// Deletes an ingredient from the system.
    /// </summary>
    /// <param name="id">The ID of the ingredient to delete.</param>
    /// <returns>
    /// Always returns a 204 No Content status on successful deletion.
    /// </returns>
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

    /// <summary>
    /// Retrieves a paginated list of recipes awaiting administrative approval.
    /// </summary>
    /// <param name="pagingParams">Pagination parameters.</param>
    /// <returns>
    /// Returns a 200 OK status with the paginated recipe data.
    /// </returns>
    /// 
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

    /// <summary>
    /// Retrieves detailed information about a specific recipe pending approval by ID.
    /// </summary>
    /// <param name="id">The ID of the recipe to retrieve.</param>
    /// <returns>
    /// Returns a 200 OK status with the detailed recipe information.
    /// </returns>
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

    /// <summary>
    /// Updates administrative notes for a recipe pending approval.
    /// That does not make it visible to other users or cooks.
    /// </summary>
    /// <param name="id">The ID of the recipe to update.</param>
    /// <param name="adminNotesDto">The data transfer object containing the admin notes.</param>
    /// <returns>
    /// Always returns a 204 No Content status on successful update.
    /// </returns>
    [HttpPut("recipes/pending-approval/{id}/notes")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [InvalidateCache(RecipeAdminCachePattern, CookOwnRecipesCachePattern)]
    public async Task<IActionResult> UpdateAdminNotesOnRecipe(int id, AdminNotesDto adminNotesDto)
    {
        await recipeService.UpdateAdminNotesAsync(id, adminNotesDto);
        return NoContent();
    }

    /// <summary>
    /// Approves a recipe and makes it available to view for other users and cooks.
    /// </summary>
    /// <param name="id">The ID of the recipe to approve.</param>
    /// <returns>
    /// Always returns a 204 No Content status on successful approval.
    /// </returns>
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
