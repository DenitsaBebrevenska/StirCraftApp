using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<string>>> GetCategories()
    {
        var categories = await categoryService.GetCategoriesNamesAsync();
        return Ok(categories);
    }
}
