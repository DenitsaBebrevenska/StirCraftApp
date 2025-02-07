﻿using StirCraftApp.Domain.Enums;

namespace StirCraftApp.Domain.Specifications.SpecParams;

/// <summary>
/// A class that contains the parameters for filtering recipes
/// Inherits from Paging params therefor it has the properties for pagination
/// </summary>
public class RecipeSpecParams : PagingParams
{
    private string? _recipeName;

    private int? _ingredientId;

    private List<string> _categories = [];

    private List<DifficultyLevel> _difficultyLevels = [];

    public string RecipeName
    {
        get => _recipeName ?? string.Empty;
        set => _recipeName = value;
    }

    public List<string> Categories
    {
        get => _categories;
        set => _categories = value.SelectMany(x => x.Split(',',
            StringSplitOptions.RemoveEmptyEntries))
            .Select(x => x.ToLower())
            .ToList();
    }

    public List<DifficultyLevel> DifficultyLevels
    {
        get => _difficultyLevels;
        set => _difficultyLevels = value
            .Select(x => Enum.TryParse(x.ToString(), true, out DifficultyLevel level) ? level : (DifficultyLevel?)null)
            .Where(x => x.HasValue)
            .Select(x => x!.Value)
            .ToList();
    }

    public int? IngredientId
    {
        get => _ingredientId;
        set => _ingredientId = value;
    }

    public string? Sort { get; set; }

}
