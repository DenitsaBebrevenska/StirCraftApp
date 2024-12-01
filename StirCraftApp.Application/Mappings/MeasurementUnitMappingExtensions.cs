using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Mappings;
public static class MeasurementUnitMappingExtensions
{
    public static MeasurementUnitDto ToMeasurementUnitDto(this MeasurementUnit measurementUnit)
    {
        return new MeasurementUnitDto
        {
            Id = measurementUnit.Id,
            Name = measurementUnit.Name,
            Abbreviation = measurementUnit.Abbreviation
        };
    }
    public static MeasurementUnit ToMeasurementUnit(this MeasurementUnitDto measurementUnitDto)
    {
        return new MeasurementUnit
        {
            Id = measurementUnitDto.Id,
            Name = measurementUnitDto.Name,
            Abbreviation = measurementUnitDto.Abbreviation
        };
    }
}
