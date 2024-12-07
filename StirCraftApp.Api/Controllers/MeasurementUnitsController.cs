using Microsoft.AspNetCore.Mvc;
using StirCraftApp.Application.Contracts;
using StirCraftApp.Domain.Specifications.MeasurementUnitSpec;
using StirCraftApp.Domain.Specifications.SpecParams;

namespace StirCraftApp.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MeasurementUnitsController(IMeasurementUnitService measurementUnitsService) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetMeasurementUnits([FromQuery] MeasurementUnitParams unitParams)
    {
        var spec = new MeasurementUnitFilterSpecification(unitParams);
        var measurementUnits = await measurementUnitsService.GetUnitsAsync(spec);
        return Ok(measurementUnits);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMeasurementUnit(int id)
    {
        var measurementUnit = await measurementUnitsService.GetUnitById(null, id);
        return Ok(measurementUnit);
    }

}
