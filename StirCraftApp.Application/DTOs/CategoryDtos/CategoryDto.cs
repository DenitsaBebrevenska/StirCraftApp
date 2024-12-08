namespace StirCraftApp.Application.DTOs.CategoryDtos;
public class CategoryDto : BaseDto
{
    public int Id { get; set; }

    public required string Name { get; set; }
}
