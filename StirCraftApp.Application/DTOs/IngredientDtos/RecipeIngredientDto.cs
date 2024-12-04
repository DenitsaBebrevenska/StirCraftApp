using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class RecipeIngredientDto : IDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public uint? Quantity { get; set; }

    public string? MeasurementUnitName { get; set; }
}
