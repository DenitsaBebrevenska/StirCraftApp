using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.CategoryDtos;
public class CategoryDto : IDto
{
    public int Id { get; set; }

    public required string Name { get; set; }
}
