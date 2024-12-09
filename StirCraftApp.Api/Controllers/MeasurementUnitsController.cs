using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Api.Attributes;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
using StirCraftApp.Domain.Specifications.SpecParams;
using static StirCraftApp.Domain.Constants.CachingValues;


namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Cache(GenerousSlidingSeconds, GenerousAbsoluteSeconds)]
public class MeasurementUnitsController(IMeasurementUnitService measurementUnitsService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetMeasurementUnits([FromQuery] MeasurementUnitParams unitParams)
    {
        var spec = new MeasurementUnitFilterSpecification(unitParams);
        var measurementUnits = await measurementUnitsService
            .GetUnitsAsync(spec);
        return Ok(measurementUnits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMeasurementUnit(int id)
    {
        var measurementUnit = await measurementUnitsService
            .GetUnitById(null, id);
        return Ok(measurementUnit);
    }

}
