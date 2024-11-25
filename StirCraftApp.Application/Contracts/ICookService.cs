using StirCraftApp.Application.DTOs.CookDtos;

namespace StirCraftApp.Application.Contracts;
public interface ICookService
{
    Task<int?> GetCookId(string userId);
    Task CreateCookAsync(BecomeCookDto dto, string userId);
}
