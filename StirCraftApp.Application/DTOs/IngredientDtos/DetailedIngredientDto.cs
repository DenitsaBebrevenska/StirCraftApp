using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class DetailedIngredientDto : IDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public bool IsAllergen { get; set; }

    public string? NameInPlural { get; set; }

    public bool IsSolid { get; set; }
}
