using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using StirCraftApp.Infrastructure.Identity;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Application.Services;
public class CookService(IUnitOfWork unit, UserManager<AppUser> userManager) : ICookService
{
    public async Task<int?> GetCookId(string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        var cook = cooks.FirstOrDefault(c => c.UserId == userId);

        return cook?.Id;
    }

    public async Task CreateCookAsync(BecomeCookDto dto, string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        if (cooks.Any(c => c.UserId == userId))
        {
            throw new Exception($"The user is a cook already.");
        }

        var newCook = new Cook
        {
            UserId = userId,
            About = dto.About,
            RankingPoints = 0,
            CookingRankId = 1
        };

        await unit.Repository<Cook>().AddAsync(newCook);

        await unit.CompleteAsync();

        var user = await userManager.FindByIdAsync(userId);
        if (user != null)
        {
            await userManager.AddToRoleAsync(user, CookRoleName);
        }
    }

    public async Task<bool> CookIsTheRecipeOwner(int cookId, int recipeId)
    {
        var spec = new CookIncludeAllSpecification();
        var cookEntity = await unit.Repository<Cook>()
            .GetByIdAsync(spec, cookId);

        if (cookEntity == null)
        {
            throw new Exception($"Cook Id not found.");
        }

        return cookEntity.Recipes.Any(r => r.Id == recipeId);
    }
}
