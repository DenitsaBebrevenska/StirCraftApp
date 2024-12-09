using StirCraftApp.Application.Contracts;
using StirCraftApp.Application.DTOs.MeasurementUnitDtos;
using StirCraftApp.Application.Exceptions;
using StirCraftApp.Application.Mappings;
using StirCraftApp.Domain.Contracts;
using StirCraftApp.Domain.Entities;
using static StirCraftApp.Domain.Constants.ExceptionErrorMessages;

namespace StirCraftApp.Application.Services;
public class MeasurementUnitService(IUnitOfWork unit) : IMeasurementUnitService
{
    public async Task<MeasurementUnitDto> GetUnitById(ISpecification<MeasurementUnit>? spec, int id)
    {
        var measurementUnit = await unit.Repository<MeasurementUnit>().GetByIdAsync(spec, id);

        if (measurementUnit == null)
        {
            throw new NotFoundException(string.Format(ResourceNotFound, nameof(MeasurementUnit), id));
        }

        return measurementUnit.ToMeasurementUnitDto();
    }

    public async Task<IList<MeasurementUnitDto>> GetUnitsAsync(ISpecification<MeasurementUnit>? spec)
    {
        var measurementUnits = await unit.Repository<MeasurementUnit>().GetAllAsync(spec);

        return measurementUnits.Select(x => x.ToMeasurementUnitDto()).ToList();
    }
}
