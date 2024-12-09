using StirCraftApp.Application.DTOs.CookDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<int> GetCookIdAsync(string userId);

    Task<CookAboutDto> GetCookAboutAsync(string userId);
    Task CreateCookAsync(CookAboutDto aboutDto, string userId);

    Task UpdateAboutAsync(string userId, CookAboutDto aboutDto);

    Task<bool> CookIsTheRecipeOwner(int cookId, int recipeId);

    Task<bool> IsCookAsync(string userId);
}
