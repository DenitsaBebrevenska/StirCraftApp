namespace StirCraftApp.Application.DTOs.RecipeDtos;
public class EditRecipeFormIngredientDto
{
    public int IngredientId { get; set; }
    public required string IngredientName { get; set; }
    public uint? Quantity { get; set; }
    public int? MeasurementUnitId { get; set; }

    public string? MeasurementUnitName { get; set; }
}
