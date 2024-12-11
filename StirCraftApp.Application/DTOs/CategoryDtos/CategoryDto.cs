namespace StirCraftApp.Application.DTOs.CategoryDtos;

/// <summary>
/// Data Transfer Object for Category
/// </summary>
public class CategoryDto : BaseDto
{
    /// <summary>
    /// Unique identifier for the category
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the category
    /// </summary>
    public required string Name { get; set; }
}
