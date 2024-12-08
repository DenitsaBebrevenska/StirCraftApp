using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface ICooksService
{
    Task<T> GetCookByIdAsync<T>(int id, Func<Cook, Task<T>> convertToDto) where T : BaseDto;

    Task<PaginatedResult<T>> GetCooksAsync<T>(ISpecification<Cook> spec, Func<Cook, Task<T>> convertToDto)
        where T : BaseDto;

}
