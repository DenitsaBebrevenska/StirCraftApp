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

/// <summary>
/// Implements the ICookService interface and uses the Unit of Work pattern for data access.
/// Provides functionality for managing cooks in the system. This service allows users to become cooks, 
/// update their profile information (like the "About" section), check if a user is a cook, 
/// retrieve cook-specific information (such as the cook's "About" data), 
/// and check if a cook is the owner of a specific recipe.
/// </summary>
public class CookService(IUnitOfWork unit, UserManager<AppUser> userManager) : ICookService
{
    /// <summary>
    /// Retrieves the cook's ID based on their user ID.
    /// Validates the existence of the cook and throws a Validation exception if the cook does not exist.
    /// </summary>
    /// <param name="userId">The user ID of the cook.</param>
    /// <returns>The ID of the cook.</returns>
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


    /// <summary>
    /// Retrieves the "About" section of a cook's profile.
    /// Validates the existence of the cook and throws a Validation exception if the cook does not exist.
    /// </summary>
    /// <param name="userId">The user ID of the cook.</param>
    /// <returns>A <see cref="CookAboutDto"/> containing the cook's "About" data.</returns>
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

    /// <summary>
    /// Allows a user to become a cook and sets their profile's "About" section.
    /// Validates if the user is already cook and throws a Validation exception if the user is already a cook.
    /// </summary>
    /// <param name="aboutDto">A <see cref="CookAboutDto"/> containing the "About" information.</param>
    /// <param name="userId">The user ID of the person wishing to become a cook.</param>
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


    /// <summary>
    /// Updates the "About" section of a cook's profile.
    /// Validates if the user is a cook and throws Validation exception if he is not.
    /// </summary>
    /// <param name="userId">The user ID of the cook.</param>
    /// <param name="aboutDto">A <see cref="CookAboutDto"/> containing the updated "About" information.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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

    /// <summary>
    /// Checks if a cook is the owner of a given recipe.
    /// Validates the existence of a cook with the given id and throws a NotFoundException if the cook does not exist.
    /// </summary>
    /// <param name="cookId">The cook ID.</param>
    /// <param name="recipeId">The recipe ID.</param>
    /// <returns>A boolean indicating whether the cook is the owner of the recipe.</returns>
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

    /// <summary>
    /// Checks if a user is registered as a cook.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <returns>A boolean indicating whether the user is a cook.</returns>
    public async Task<bool> IsCookAsync(string userId)
    {
        var cooks = await unit.Repository<Cook>().GetAllAsync(null);
        return cooks.Any(c => c.UserId == userId);
    }
}
