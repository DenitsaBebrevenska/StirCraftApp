using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;

/// <summary>
/// This class contains extension methods for mapping between <see cref="Category"/> and <see cref="CategoryDto"/>
/// </summary>
public static class CategoryMappingExtensions
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}
