using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[AllowAnonymous]
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
public class CategoriesController(ICategoryService categoryService) : BaseApiController
{
    [HttpGet("names")]
    public async Task<ActionResult<List<string>>> GetCategoriesNames()
    {
        var categories = await categoryService.GetCategoriesNamesAsync();
        return Ok(categories);
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetCategories()
    {
        var categories = await categoryService.GetAll();
        return Ok(categories);
    }
}
