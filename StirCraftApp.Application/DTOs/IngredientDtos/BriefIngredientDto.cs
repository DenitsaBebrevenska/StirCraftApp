namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class BriefIngredientDto : BaseDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public bool IsAllergen { get; set; }

}
