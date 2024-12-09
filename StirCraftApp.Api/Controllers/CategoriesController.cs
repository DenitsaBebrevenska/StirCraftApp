using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CategoryDtos;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
public class CategoriesController(ICategoryService categoryService) : BaseApiController
{
    [HttpGet("names")]
    [ProducesResponseType(typeof(IList<string>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategoriesNames()
    {
        var categories = await categoryService.GetCategoriesNamesAsync();
        return Ok(categories);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IList<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await categoryService.GetAll();
        return Ok(categories);
    }
}
