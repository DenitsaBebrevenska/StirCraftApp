namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class EditRecipeIngredientDto : BaseDto
{
    public int Id { get; set; }

    public required string IngredientName { get; set; }
    public int IngredientId { get; set; }
    public uint? Quantity { get; set; }

    public string? MeasurementAbbreviation { get; set; }
    public int? MeasurementUnitId { get; set; }
}
