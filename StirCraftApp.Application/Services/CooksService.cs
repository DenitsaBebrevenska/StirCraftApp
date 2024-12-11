using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Results;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using StirCraftApp.Domain.Specifications.CookSpec;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implements the ICooksService interface and uses the Unit of Work pattern for data access.
/// Provides functionality for managing and retrieving cook-related data. 
/// This service includes methods for fetching a single cook by ID, 
/// as well as retrieving paginated lists of cooks, which can be transformed 
/// into data transfer objects (DTOs) using a provided conversion function.
/// </summary>
public class CooksService(IUnitOfWork unit) : ICooksService
{
    /// <summary>
    /// Retrieves a cook by their ID and converts the cook entity into a DTO.
    /// </summary>
    /// <typeparam name="T">The type of DTO to return, which must derive from <see cref="BaseDto"/>.</typeparam>
    /// <param name="id">The ID of the cook to retrieve.</param>
    /// <param name="convertToDto">A function that converts the cook entity to the specified DTO type.</param>
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

    /// <summary>
    /// Retrieves a paginated list of cooks and converts each cook entity into a DTO.
    /// </summary>
    /// <typeparam name="T">The type of DTO to return, which must derive from <see cref="BaseDto"/>.</typeparam>
    /// <param name="spec">The specification to filter the cooks.</param>
    /// <param name="convertToDto">A function that converts each cook entity to the specified DTO type.</param>
    public async Task<PaginatedResult<T>> GetCooksAsync<T>(ISpecification<Cook> spec, Func<Cook, Task<T>> convertToDto) where T : BaseDto
    {
        var cooks = await unit.Repository<Cook>()
            .GetAllAsync(spec);
        var count = await unit.Repository<Cook>()
            .CountAsync(spec);
        var cookDtos = new List<T>();

        foreach (var cook in cooks)
        {
            cookDtos.Add(await convertToDto(cook));
        }

        var paginatedResult = new PaginatedResult<T>(spec.Skip,
            spec.Take,
            count,
            cookDtos);

        return paginatedResult;

    }

}
