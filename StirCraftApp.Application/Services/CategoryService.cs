using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class CategoryService(IUnitOfWork unit) : ICategoryService
{
    public async Task<IList<string>> GetCategoriesNamesAsync()
    {
        var categories = await unit.Repository<Category>()
            .GetAllAsync(null);

        return categories
        .Select(c => c.Name)
        .ToList();
    }

    public async Task<IList<CategoryDto>> GetAll()
    {
        var categories = await unit.Repository<Category>()
            .GetAllAsync(null);

        return categories
            .Select(c => c.ToDto())
            .ToList();
    }
}
