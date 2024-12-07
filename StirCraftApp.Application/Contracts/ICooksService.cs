using StirCraftApp.Application.Common;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface ICooksService
{
    Task<object> GetCookByIdAsync(int id, string dtoName);
    Task<PaginatedResult> GetCooksAsync(ISpecification<Cook> spec, string dtoName);

}
