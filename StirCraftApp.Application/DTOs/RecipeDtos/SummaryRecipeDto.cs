﻿namespace StirCraftApp.Application.DTOs.RecipeDtos;

public class SummaryRecipeDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required string DifficultyLevel { get; set; }

    public string? MainImageUrl { get; set; }

    public required string CookName { get; set; }

    public double Rating { get; set; }

    public int Likes { get; set; }

    public IList<string> Categories { get; set; } = [];

}
