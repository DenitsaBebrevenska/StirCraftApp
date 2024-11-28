using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Infrastructure.Extensions;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CookController(IRecipeService recipeService, ICookService cookService) : ControllerBase
{

    [HttpPost("become")]
    public async Task<IActionResult> BecomeCook(BecomeCookDto dto)
    {
        var userId = User.GetId();

        await cookService.CreateCookAsync(dto, userId);
        return Ok();
    }

    //todo comment, reply, rate, view profile, edit avatar, view liked recipes

}
