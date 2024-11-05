namespace StirCraftApp.Application.Contracts;
public interface ICategoryService
{
    Task<List<string>> GetCategoriesNamesAsync();
}
