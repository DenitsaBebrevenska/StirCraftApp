using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;

/// <summary>
/// Provides endpoints for managing measurement units, including retrieval of a list of all units or specific units by ID.
/// </summary>
/// <remarks>
/// All endpoints in this controller are accessible anonymously and use generous caching for optimized performance.
/// Routing is configured to use the "api/measurementUnits/" path by BaseApiController configurations.
/// </remarks>
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
[AllowAnonymous]
public class MeasurementUnitsController(IMeasurementUnitService measurementUnitsService) : BaseApiController
{
    /// <summary>
    /// Retrieves a list of all measurement units.
    /// </summary>
    /// <returns>
    /// Returns a 200 OK status with a list of measurement units as <see cref="IList{MeasurementUnitDto}"/>.
    /// </returns>
    [HttpGet]
    [ProducesResponseType(typeof(IList<MeasurementUnitDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMeasurementUnits()
    {
        var spec = new MeasurementUnitFilterSpecification();
        var measurementUnits = await measurementUnitsService
            .GetUnitsAsync(spec);
        return Ok(measurementUnits);
    }

    /// <summary>
    /// Retrieves details of a specific measurement unit by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the measurement unit.</param>
    /// <returns>
    /// Returns a 200 OK status with the measurement unit details as a <see cref="MeasurementUnitDto"/>.
    /// </returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MeasurementUnitDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMeasurementUnit(int id)
    {
        var measurementUnit = await measurementUnitsService
            .GetUnitById(null, id);
        return Ok(measurementUnit);
    }

}
