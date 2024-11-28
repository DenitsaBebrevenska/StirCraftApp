using StirCraftApp.Application.Contracts;

namespace StirCraftApp.Application.DTOs.MeasurementUnitDtos;
public class MeasurementUnitDto : IDto
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public required string Abbreviation { get; set; }

    public bool IsLiquidSpecific { get; set; }

    public bool IsSolidSpecific { get; set; }

}
