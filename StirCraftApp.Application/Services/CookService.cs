using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Infrastructure.Identity;

namespace StirCraftApp.Application.Services;
public class CookService(IUnitOfWork unit, UserManager<AppUser> userManager) : ICookService
{
    public async Task<DetailedCookDto> GetCookByIdAsync(int id)
    {
        var cookExists = await unit.Repository<Cook>()
            .ExistsAsync(id);

        if (!cookExists)
        {
            throw new Exception($"Cook with id {id} was not found.");
        }

        var spec = new CookIncludeAllSpecification();
        var cook = await unit.Repository<Cook>()
            .GetEntityWithSpecAsync(spec, id);

        var cookDto = new DetailedCookDto
        {
            Id = cook!.Id,
            DisplayName = userManager.Users.FirstOrDefault(u => u.Id == cook.UserId)?.DisplayName ?? "",
            About = cook.About,
            RankingPoints = cook.RankingPoints,
            CookingRank = cook.CookingRank.Title
        };

        return cookDto;
    }

    public async Task<PaginatedResult> GetCooksAsync(CookSortIncludeSpecification spec)
    {
        //var cooks = await unit.Repository<Cook>()
        //    .GetAllWithSpecAsync(spec);

        //var cookDtos = cooks.Select(c => new SummaryCookDto
        //{
        //    Id = c.Id,
        //    DisplayName = userManager.Users.FirstOrDefault(u => u.Id == c.UserId)?.DisplayName ?? "",
        //    RankingPoints = c.RankingPoints,
        //    CookingRank = c.CookingRank.Title,
        //    RecipesCount = (uint)c.Recipes.Count
        //}).ToList();

        //var paginatedResult = new PaginatedResult(spec.Skip,
        //    spec.Take,
        //    cookDtos.Count,
        //    cookDtos);

        //return paginatedResult;

        return null;
    }
}
