﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.RecipeSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using StirCraftApp.Infrastructure.Extensions;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = CookRoleName)]
public class CookController(IRecipeService recipeService, ICookService cookService, UserManager<AppUser> userManager) : ControllerBase
{

    [HttpGet("about")]
    public async Task<IActionResult> GetAbout()
    {
        var userId = User?.GetId();

        if (userId == null)
        {
            return NotFound();
        }

        var about = await cookService.GetCookAbout(userId);
        return Ok(about);
    }

    [Authorize(Roles = UserRoleName)]
    [HttpPost("become")]
    public async Task<IActionResult> BecomeCook(CookAboutDto aboutDto)
    {
        var userId = User.GetId();

        await cookService.CreateCookAsync(aboutDto, userId);
        return Ok();
    }


    [HttpPut("about")]
    public async Task<IActionResult> UpdateAbout(CookAboutDto aboutDto)
    {
        var userId = User.GetId();
        await cookService.UpdateAboutAsync(userId, aboutDto);
        return Ok();
    }



    [HttpGet("recipes")]
    public async Task<IActionResult> GetCooksOwnRecipes([FromQuery] PagingParams pagingParams)
    {
        var cookId = await cookService.GetCookId(User.GetId());

        if (cookId == null)
        {
            return NotFound();
        }

        var spec = new RecipesByCurrentCookSpecification(pagingParams, (int)cookId);
        var cookRecipes = await recipeService
            .GetRecipesAsync(spec, async recipe => await recipe
                .ToRecipeOwnDtoAsync(userManager));
        return Ok(cookRecipes);
    }

    [HttpGet("recipes/{id}")]
    public async Task<IActionResult> GetCookOwnRecipeById(int id)
    {
        var cookId = await cookService.GetCookId(User.GetId());

        if (cookId == null)
        {
            return NotFound();
        }

        if (await cookService.CookIsTheRecipeOwner((int)cookId, id) == false)
        {
            return Unauthorized();
        }

        var spec = new RecipeIncludeAllSpecification();


        var recipe = await recipeService
            .GetRecipeByIdAsync(spec, id, async recipe => await recipe
                .ToDetailedRecipeAdminNotesDtoAsync(userManager));
        return Ok(recipe);
    }

}
