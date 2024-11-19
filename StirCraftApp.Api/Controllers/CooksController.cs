using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CooksController(ICookService cookService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCooks([FromQuery] CookSpecParams specParams)
    {
        var spec = new CookSortIncludeSpecification(specParams);
        var cooks = await cookService.GetCooksAsync(spec, nameof(SummaryCookDto));
        return Ok(cooks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCookById(int id)
    {
        var cook = await cookService.GetCookByIdAsync(id, nameof(DetailedCookDto));
        return Ok(cook);
    }

    [HttpGet("top/{count}")]
    public async Task<IActionResult> GetTopTenCooksWithRanks(int count)
    {
        var spec = new CookTopRankSpecification(count);
        var cooks = await cookService.GetCooksAsync(spec, nameof(CookWithRankDto));
        return Ok(cooks);
    }
}
