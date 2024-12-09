using Microsoft.AspNetCore.Identity;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.CookDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;
using static StirCraftApp.Domain.Constants.RoleConstants;

namespace StirCraftApp.Application.Services;
public class CookService(IUnitOfWork unit, UserManager<AppUser> userManager) : ICookService
{
    public async Task<int> GetCookIdAsync(string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        var cook = cooks.FirstOrDefault(c => c.UserId == userId);

        if (cook == null)
        {
            throw new ValidationException(string.Format(UserIsNotCook, userId));
        }

        return cook.Id;
    }

    public async Task<CookAboutDto> GetCookAboutAsync(string userId)
    {

        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        var cook = cooks.FirstOrDefault(c => c.UserId == userId);

        if (cook == null)
        {
            throw new ValidationException(string.Format(UserIsNotCook, userId));
        }

        return new CookAboutDto
        {
            About = cook.About
        };
    }

    public async Task BecomeCookAsync(CookAboutDto aboutDto, string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        if (cooks.Any(c => c.UserId == userId))
        {
            throw new ValidationException(string.Format(UserIsCookAlready, userId));
        }

        var newCook = aboutDto.ToCook(userId);

        await unit.Repository<Cook>().AddAsync(newCook);

        await unit.CompleteAsync();

        var user = await userManager.FindByIdAsync(userId);

        await userManager.AddToRoleAsync(user!, CookRoleName);
        await userManager.RemoveFromRoleAsync(user!, UserRoleName);

    }

    public async Task UpdateAboutAsync(string userId, CookAboutDto aboutDto)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);

        var cook = cooks.FirstOrDefault(c => c.UserId == userId);

        if (cook == null)
        {
            throw new ValidationException(string.Format(UserIsNotCook, userId));
        }

        cook.About = aboutDto.About;
        unit.Repository<Cook>().Update(cook);

        await unit.CompleteAsync();
    }

    public async Task<bool> CookIsTheRecipeOwner(int cookId, int recipeId)
    {
        var spec = new CookIncludeAllSpecification();
        var cookEntity = await unit.Repository<Cook>()
            .GetByIdAsync(spec, cookId);

        if (cookEntity == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Cook), cookId));
        }

        return cookEntity.Recipes.Any(r => r.Id == recipeId);
    }

    public async Task<bool> IsCookAsync(string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);
        return cooks.Any(c => c.UserId == userId);
    }
}
