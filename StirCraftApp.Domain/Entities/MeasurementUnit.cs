namespace StirCraftApp.Domain.Entities;
public class MeasurementUnit : BaseEntity
{
	public required string Name { get; set; }

	public required string Abbreviation { get; set; }
}
