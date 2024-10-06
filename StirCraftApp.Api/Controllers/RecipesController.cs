using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
	private readonly IRepository<Recipe> _recipeRepository;
	//use repo for now to test out
	public RecipesController(IRepository<Recipe> recipeRepository)
	{
		_recipeRepository = recipeRepository;
	}

	[HttpGet]
	public async Task<IActionResult> GetRecipes()
	{
		var recipes = await _recipeRepository
			.GetAllAsync();

		return Ok(recipes);
	}
}
