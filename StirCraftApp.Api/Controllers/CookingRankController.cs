using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CookingRankController(ICookingRankService cookingRankService) : ControllerBase
{
    [HttpPost("/edit")]
    public async Task<IActionResult> ChangeRankingPoints([FromQuery] int cookId, string action)
    {
        await cookingRankService.CalculatePoints(cookId, action);
        return Ok();
    }
}
