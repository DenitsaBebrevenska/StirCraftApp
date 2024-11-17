using StirCraftApp.Domain.Specifications.CookSpec;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<object> GetCookByIdAsync(int id, string dtoName);
    Task<PaginatedResult> GetCooksAsync(CookSortIncludeSpecification spec, string dtoName);
}
