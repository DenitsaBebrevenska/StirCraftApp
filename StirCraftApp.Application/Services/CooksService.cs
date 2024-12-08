using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;


namespace StirCraftApp.Application.Services;
public class CooksService(IUnitOfWork unit) : ICooksService
{
    public async Task<T> GetCookByIdAsync<T>(int id, Func<Cook, Task<T>> convertToDto) where T : BaseDto
    {
        var spec = new CookIncludeAllSpecification();
        var cook = await unit.Repository<Cook>()
            .GetByIdAsync(spec, id);

        if (cook == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(Cook), id));
        }

        var cookDto = await convertToDto(cook);

        return cookDto;
    }

    public async Task<PaginatedResult<T>> GetCooksAsync<T>(ISpecification<Cook> spec, Func<Cook, Task<T>> convertToDto) where T : BaseDto
    {
        var cooks = await unit.Repository<Cook>()
            .GetAllAsync(spec);

        var cookDtos = new List<T>();

        foreach (var cook in cooks)
        {
            cookDtos.Add(await convertToDto(cook));
        }

        var paginatedResult = new PaginatedResult<T>(spec.Skip,
            spec.Take,
            cookDtos.Count,
            cookDtos);

        return paginatedResult;

    }

}
