using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Infrastructure.Identity;


namespace StirCraftApp.Application.Services;
public class CooksService(IUnitOfWork unit, UserManager<AppUser> userManager) : ICooksService
{
    public async Task<object> GetCookByIdAsync(int id, string dtoName)
    {
        var cookExists = await unit.Repository<Cook>()
            .ExistsAsync(id);

        if (!cookExists)
        {
            throw new Exception($"Cook with id {id} was not found.");
        }

        var spec = new CookIncludeAllSpecification();
        var cook = await unit.Repository<Cook>()
            .GetByIdAsync(spec, id);

        var cookDto = ConvertToDto(cook!, dtoName);

        return cookDto;
    }

    public async Task<PaginatedResult> GetCooksAsync(ISpecification<Cook> spec, string dtoName)
    {
        var cooks = await unit.Repository<Cook>()
            .GetAllAsync(spec);

        var cookDtos = cooks.Select(c => ConvertToDto(c, dtoName)).ToList();

        var paginatedResult = new PaginatedResult(spec.Skip,
            spec.Take,
            cookDtos.Count,
            cookDtos);

        return paginatedResult;

    }
    private object ConvertToDto(Cook cook, string dtoName)
    {
        return dtoName switch
        {
            nameof(SummaryCookDto) => cook.ToSummaryCookDto(userManager),
            nameof(DetailedCookDto) => cook.ToDetailedCookDto(userManager),
            nameof(CookWithRankDto) => cook.ToCookWithRankDto(userManager),
            _ => throw new ArgumentException("Invalid DTO type")
        };
    }
}
