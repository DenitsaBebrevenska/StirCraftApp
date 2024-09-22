namespace StirCraftApp.Domain.Entities;
public class MeasurementUnit
{
	public int Id { get; set; }

	public required string Name { get; set; }

	public required string Abbreviation { get; set; }
}
