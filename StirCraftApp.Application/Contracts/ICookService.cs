using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Specifications.CookSpec;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<DetailedCookDto> GetCookByIdAsync(int id);
    Task<PaginatedResult> GetCooksAsync(CookSortIncludeSpecification spec);
}
