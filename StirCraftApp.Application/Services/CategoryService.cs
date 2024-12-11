using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CategoryDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Provides methods for managing and retrieving category data.
/// Implements the ICategoryService interface and uses the Unit of Work pattern for data access.
/// </summary>
public class CategoryService(IUnitOfWork unit) : ICategoryService
{
    /// <summary>
    /// Retrieves the names of all categories from the database.
    /// </summary>
    /// <returns>A list of category names.</returns>
    public async Task<IList<string>> GetCategoriesNamesAsync()
    {
        var categories = await unit.Repository<Category>()
            .GetAllAsync(null);

        return categories
        .Select(c => c.Name)
        .ToList();
    }

    /// <summary>
    /// Retrieves all categories from the database and maps them to DTOs.
    /// </summary>
    /// <returns>A list of CategoryDto objects representing all categories.</returns>
    public async Task<IList<CategoryDto>> GetAll()
    {
        var categories = await unit.Repository<Category>()
            .GetAllAsync(null);

        return categories
            .Select(c => c.ToDto())
            .ToList();
    }
}
