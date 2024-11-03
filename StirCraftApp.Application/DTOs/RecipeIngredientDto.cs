namespace StirCraftApp.Application.DTOs;
public class RecipeIngredientDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public uint? Quantity { get; set; }

    public string? MeasurementUnitName { get; set; }
}
