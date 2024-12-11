namespace StirCraftApp.Application.DTOs.MeasurementUnitDtos;

/// <summary>
/// Data transfer object for measurement unit
/// </summary>
public class MeasurementUnitDto : BaseDto
{
    /// <summary>
    /// The unique identifier of the measurement unit
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The name of the measurement unit
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The abbreviation of the measurement unit`s name
    /// </summary>
    public required string Abbreviation { get; set; }

}
