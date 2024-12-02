﻿using StirCraftApp.Application.Contracts;


namespace StirCraftApp.Application.DTOs.RecipeDtos.Ingredient;
public class FormRecipeIngredientDto : IDto
{
    public int Id { get; set; }
    public int IngredientId { get; set; }
    public uint? Quantity { get; set; }
    public int? MeasurementUnitId { get; set; }
}
