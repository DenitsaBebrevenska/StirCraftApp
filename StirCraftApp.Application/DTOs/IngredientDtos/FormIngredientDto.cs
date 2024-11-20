using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.IngredientDtos;
public class FormIngredientDto : IDto
{
    public required string Name { get; set; }

    public bool IsAllergen { get; set; }

    public string? NameInPlural { get; set; }

    public bool IsSolid { get; set; }

    public bool IsAdminApproved { get; set; }
}
