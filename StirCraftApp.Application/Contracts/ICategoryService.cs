using StirCraftApp.Application.DTOs.CategoryDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICategoryService
{
    Task<IList<string>> GetCategoriesNamesAsync();

    Task<IList<CategoryDto>> GetAll();
}
