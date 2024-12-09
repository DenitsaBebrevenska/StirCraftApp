using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
using static StirCraftApp.Domain.Constants.CachingValues;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
[AllowAnonymous]
public class MeasurementUnitsController(IMeasurementUnitService measurementUnitsService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(typeof(IList<MeasurementUnitDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMeasurementUnits()
    {
        var spec = new MeasurementUnitFilterSpecification();
        var measurementUnits = await measurementUnitsService
            .GetUnitsAsync(spec);
        return Ok(measurementUnits);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(MeasurementUnitDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMeasurementUnit(int id)
    {
        var measurementUnit = await measurementUnitsService
            .GetUnitById(null, id);
        return Ok(measurementUnit);
    }

}
