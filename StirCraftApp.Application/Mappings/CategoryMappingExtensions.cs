using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class CategoryMappingExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
