namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class FormRecipeIngredientDto : BaseDto
{
    public int Id { get; set; }
    public int IngredientId { get; set; }
    public uint? Quantity { get; set; }
    public int? MeasurementUnitId { get; set; }
}
