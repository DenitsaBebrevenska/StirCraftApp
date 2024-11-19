using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<object> GetCookByIdAsync(int id, string dtoName);
    Task<PaginatedResult> GetCooksAsync(BaseSpecification<Cook> spec, string dtoName);
}
