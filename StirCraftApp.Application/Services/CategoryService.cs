using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;
public class CategoryService(IUnitOfWork unit) : ICategoryService
{
    public async Task<List<string>> GetCategoriesNamesAsync()
    {
        var categories = await unit.Repository<Category>()
            .GetAllAsync(null);

        return categories
        .Select(c => c.Name)
        .ToList();
    }
}
