namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class AbbreviationIngredientDto : BaseDto
{
    public int Id { get; set; }

    public required string Abbreviation { get; set; }
}
