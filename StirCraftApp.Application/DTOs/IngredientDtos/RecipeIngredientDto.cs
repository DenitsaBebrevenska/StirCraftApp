namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class RecipeIngredientDto : BaseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public int? Quantity { get; set; }

    public string? MeasurementUnitName { get; set; }
}
