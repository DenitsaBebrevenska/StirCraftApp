using StirCraftApp.Application.DTOs.CookDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<int> GetCookIdAsync(string userId);

    Task<CookAboutDto> GetCookAboutAsync(string userId);
    Task BecomeCookAsync(CookAboutDto aboutDto, string userId);

    Task UpdateAboutAsync(string userId, CookAboutDto aboutDto);

    Task<bool> IsCookAsync(string userId);
}
