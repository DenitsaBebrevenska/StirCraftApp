using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
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
