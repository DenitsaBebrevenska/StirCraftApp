﻿namespace StirCraftApp.Domain.Specifications.SpecParams;
public class IngredientSpecParams : PagingParams
{
    private string? _ingredientName;

    private bool? _isAllergen;

    public string IngredientName
    {
        get => _ingredientName ?? string.Empty;
        set => _ingredientName = value.ToLower();
    }

    public bool? IsAllergen
    {
        get => _isAllergen;
        set => _isAllergen = value;
    }

}