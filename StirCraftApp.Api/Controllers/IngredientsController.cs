﻿using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.IngredientDtos;
using StirCraftApp.Domain.Specifications.IngredientSpec;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class IngredientsController(IIngredientService ingredientService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetIngredients([FromQuery] IngredientSpecParams specParams)
    {
        var spec = new IngredientFilterAdminApprovedSpecification(specParams);
        var ingredients = await ingredientService.GetIngredientsAsync(spec, nameof(BriefIngredientDto));

        return Ok(ingredients);
    }

    [HttpPost("suggest")]
    public async Task<IActionResult> SuggestIngredient(SuggestIngredientDto dto)
    {
        await ingredientService.SuggestIngredient(dto);
        return Ok();
        //todo name check
    }
}
