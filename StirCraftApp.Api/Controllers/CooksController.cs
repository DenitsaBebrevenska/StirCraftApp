﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;



namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CooksController(ICooksService cooksService, UserManager<AppUser> userManager) : ControllerBase
{
    [HttpGet]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetCooks([FromQuery] CookSpecParams specParams)
    {
        var spec = new CookSortIncludeSpecification(specParams);
        var cooks = await cooksService
            .GetCooksAsync(spec, cook => cook
                .ToSummaryCookDtoAsync(userManager));
        return Ok(cooks);
    }

    [HttpGet("{id}")]
    [Cache(ModerateSlidingSeconds, ModerateAbsoluteSeconds)]
    public async Task<IActionResult> GetCookById(int id)
    {
        var cook = await cooksService
            .GetCookByIdAsync(id, cook => cook
                .ToDetailedCookDtoAsync(userManager));
        return Ok(cook);
    }

    [HttpGet("top/{count}")]
    [Cache(QuickSlidingSeconds, QuickAbsoluteSeconds)]
    public async Task<IActionResult> GetTopTenCooksWithRanks(int count)
    {
        var spec = new CookTopRankSpecification(count);
        var cooks = await cooksService
            .GetCooksAsync(spec, cook => cook
                .ToCookWithRankDtoAsync(userManager));
        return Ok(cooks);
    }
}
