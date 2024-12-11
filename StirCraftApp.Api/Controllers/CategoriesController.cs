using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CategoryDtos;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Provides endpoints for retrieving category data in the StirCraft application.
/// </summary>
/// <remarks>
/// This controller allows anonymous access to retrieve category names and full category details. 
/// Data is cached to optimize performance.
/// Categories are only being read and not modified, therefor caching is used generously.
/// Routing is configured to use the "api/categories/" path by the default behavior of the BaseApiController class.
/// </remarks>
[AllowAnonymous]
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
public class CategoriesController(ICategoryService categoryService) : BaseApiController
{
    /// <summary>
    /// Retrieves a list of all category names.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with a list of category names as strings.
    /// </returns>
    [HttpGet("names")]
    [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoriesNames()
    {
        var categories = await categoryService.GetCategoriesNamesAsync();
        return Ok(categories);
    }

    /// <summary>
    /// Retrieves a list of all categories with detailed information.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with a list of categories as data transfer objects (DTOs).
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await categoryService.GetAll();
        return Ok(categories);
    }
}
