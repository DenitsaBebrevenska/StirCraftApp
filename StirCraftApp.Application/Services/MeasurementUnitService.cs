using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;

/// <summary>
/// Implements the IMeasurementUnitService interface and uses the Unit of Work pattern for data access.
/// Provides functionality for managing measurement units in the system. This service supports retrieving measurement units
/// by ID and fetching lists of measurement units, optionally filtered by a specification. The service ensures that 
/// measurement units are converted to DTOs before being returned to the client.
/// </summary>
public class MeasurementUnitService(IUnitOfWork unit) : IMeasurementUnitService
{
    /// <summary>
    /// Retrieves a measurement unit by its ID, converting it into a <see cref="MeasurementUnitDto"/>.
    /// </summary>
    /// <param name="spec">An optional specification to filter the measurement unit.</param>
    /// <param name="id">The ID of the measurement unit to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation, with the measurement unit DTO as the result.</returns>
    public async Task<MeasurementUnitDto> GetUnitById(ISpecification<MeasurementUnit>? spec, int id)
    {
        var measurementUnit = await unit.Repository<MeasurementUnit>().GetByIdAsync(spec, id);

        if (measurementUnit == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(MeasurementUnit), id));
        }

        return measurementUnit.ToMeasurementUnitDto();
    }

    /// <summary>
    /// Retrieves a list of measurement units, optionally filtered by a specification.
    /// </summary>
    /// <param name="spec">An optional specification to filter the measurement units.</param>
    /// <returns>A task that represents the asynchronous operation, with a list of measurement unit DTOs as the result.</returns>
    public async Task<IList<MeasurementUnitDto>> GetUnitsAsync(ISpecification<MeasurementUnit>? spec)
    {
        var measurementUnits = await unit.Repository<MeasurementUnit>().GetAllAsync(spec);

        return measurementUnits.Select(x => x.ToMeasurementUnitDto()).ToList();
    }
}
