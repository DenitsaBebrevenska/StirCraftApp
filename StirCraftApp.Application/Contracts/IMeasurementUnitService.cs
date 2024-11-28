using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;

namespace StirCraftApp.Application.Contracts;
public interface IMeasurementUnitService
{
    Task<MeasurementUnitDto> GetUnitById(ISpecification<MeasurementUnit>? spec, int id);
    Task<IList<MeasurementUnitDto>> GetUnitsAsync(ISpecification<MeasurementUnit>? spec);
}
