namespace StirCraftApp.Application.DTOs.RecipeDtos.Ingredient;
public class EditRecipeIngredientDto
{
    public int Id { get; set; }

    public required string IngredientName { get; set; }
    public int IngredientId { get; set; }
    public uint? Quantity { get; set; }

    public string? MeasurementAbbreviation { get; set; }
    public int? MeasurementUnitId { get; set; }
}
